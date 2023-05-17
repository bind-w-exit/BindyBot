using BindyBot.Api.Data.Contracts;
using BindyBot.Api.Models;
using BindyBot.Api.Models.Dtos;
using BindyBot.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace BindyBot.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IHashService _hashService;
    private readonly ITokenService _tokenService;
    private readonly IRevokedTokenRepository _revokedTokenRepository;

    public AuthController(IUserRepository userRepository, IHashService hashService, ITokenService tokenService, IRevokedTokenRepository revokedTokenRepository)
    {
        _userRepository = userRepository;
        _hashService = hashService;
        _tokenService = tokenService;
        _revokedTokenRepository = revokedTokenRepository;
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UserDto>> Register(UserRegisterDto userRegisterDto)
    {
        _hashService.CreatePasswordHash(userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var userFromRepo = await _userRepository.CreateAsync(
            new User(userRegisterDto.Username, passwordHash, passwordSalt, userRegisterDto.UserRole)
        );

        UserDto userDto = new(userFromRepo);
        return Ok(userDto);
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AuthenticatedResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<AuthenticatedResponse>> Login(UserLoginDto userLoginDto)
    {
        var userFromRepo = await _userRepository.GetByLoginAsync(userLoginDto.Username);

        if (userFromRepo == null)
            return BadRequest("User not found.");

        if (!_hashService.VerifyPasswordHash(userLoginDto.Password, userFromRepo.PasswordHash, userFromRepo.PasswordSalt))
            return BadRequest("Wrong password.");

        AuthenticatedResponse response = _tokenService.GenerateAuthenticatedResponse(userFromRepo);
        return Ok(response);
    }

    [HttpDelete("Logout")]
    [Authorize(Roles = "Admin,User")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Logout()
    {
        // Validation 1: Ensure that the JTI is valid
        var jtiString = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
        if (string.IsNullOrEmpty(jtiString) || !Guid.TryParse(jtiString, out var jti))
        {
            return BadRequest("Invalid JTI");
        }

        // Validation 2: Check if the token is already in the blacklist
        var revokedToken = await _revokedTokenRepository.GetByJtiAsync(jti);
        if (revokedToken != null)
        {
            return BadRequest("Token has already been revoked");
        }

        // Validation 3: Ensure that the token expiry time is valid
        var tokenExpiresString = User.FindFirstValue(JwtRegisteredClaimNames.Exp);
        if (string.IsNullOrEmpty(tokenExpiresString) || !long.TryParse(tokenExpiresString, out long tokenExpiresSeconds))
        {
            return BadRequest("Invalid Exp");
        }

        var tokenExpires = DateTimeOffset.FromUnixTimeSeconds(tokenExpiresSeconds);
        if (tokenExpires <= DateTimeOffset.UtcNow)
        {
            return BadRequest("Token has expired");
        }

        // Add tokens to the blacklist
        await _revokedTokenRepository.CreateAsync(new RevokedToken
        {
            Jti = jti,
            ExpiryDate = tokenExpires.UtcDateTime
        });

        return Ok();
    }

    [HttpGet("Refresh")]
    [Authorize(Roles = "RefreshToken")]
    [ProducesResponseType(typeof(AuthenticatedResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<AuthenticatedResponse>> Refresh()
    {
        // Validation 1: Ensure that the JTI is valid
        var jtiString = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
        if (string.IsNullOrEmpty(jtiString) || !Guid.TryParse(jtiString, out var jti))
        {
            return BadRequest("Invalid JTI");
        }

        // TODO: Move to the AuthMiddleware
        // Validation 2: Ensure that the token is not in the blacklist
        var revokedToken = await _revokedTokenRepository.GetByJtiAsync(jti);
        if (revokedToken != null)
        {
            return BadRequest("Token has been used");
        }

        // Validation 3: Ensure that the token expiry time is valid
        var tokenExpiresString = User.FindFirstValue(JwtRegisteredClaimNames.Exp);
        if (string.IsNullOrEmpty(tokenExpiresString) || !long.TryParse(tokenExpiresString, out long tokenExpiresSeconds))
        {
            return BadRequest("Invalid Exp");
        }
        var tokenExpires = DateTimeOffset.FromUnixTimeSeconds(tokenExpiresSeconds);

        // Validation 4: Ensure that the user ID is valid
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int userIdValue))
        {
            return BadRequest("Invalid user ID");
        }

        var user = await _userRepository.GetByIdAsync(userIdValue);
        if (user == null)
        {
            return BadRequest("User not found");
        }

        // Add old tokens to the blacklist
        await _revokedTokenRepository.CreateAsync(new RevokedToken
        {
            Jti = jti,
            ExpiryDate = tokenExpires.UtcDateTime
        });

        AuthenticatedResponse response = _tokenService.GenerateAuthenticatedResponse(user);
        return Ok(response);
    }
}
