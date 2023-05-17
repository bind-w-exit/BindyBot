using BindyBot.Api.Data.Contracts;
using BindyBot.Api.Models;
using BindyBot.TwitchApi.Enums;
using BindyBot.TwitchApi.Models;
using BindyBot.TwitchApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Threading.RateLimiting;

namespace BindyBot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TwitchAuthController : ControllerBase
{
    private readonly ITwitchUserCredentialsRepository _twitchUserCredentialsRepository;
    private readonly IConfiguration _configuration;
    private readonly TwitchAuthService _twitchAuthService;

    private string? _authorizationCodeUrl;

    public TwitchAuthController(ITwitchUserCredentialsRepository twitchUserCredentialsRepository, IConfiguration configuration, TwitchAuthService twitchAuthService)
    {
        _twitchUserCredentialsRepository = twitchUserCredentialsRepository;
        _configuration = configuration;
        _twitchAuthService = twitchAuthService;
    }

    [HttpGet("AuthCodeUrl")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public ActionResult<string> GetAuthorizationCodeUrl()
    {
        if (_authorizationCodeUrl is null)
        {
            var clientId = _configuration["TWITCH_CLIENT_ID"]!;
            var redirectUri = @"http://localhost:3000/callback";

            List<AuthScopes> scopes = new()
            {
                AuthScopes.ChatRead,
                AuthScopes.ChatEdit,
                AuthScopes.ChannelModerate
            };

            _authorizationCodeUrl = TwitchAuthService.GetAuthorizationCodeUrl(clientId, redirectUri, scopes);
        }

        return Ok(_authorizationCodeUrl);
    }

    [HttpPost("Authorize/{code}")]
    [Authorize(Roles = "Admin,User")]
    [ProducesResponseType(typeof(TwitchUserCredentials), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<TwitchUserCredentials>> Authorize(string code)
    {
        // Validation 1: Ensure that the user ID is valid
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int userIdValue))
        {
            return BadRequest("Invalid user ID");
        }

        var clientId = _configuration["TWITCH_CLIENT_ID"]!;
        var clientSecret = _configuration["TWITCH_CLIENT_SECRET"]!;
        var redirectUri = @"http://localhost:3000/callback";

        AuthCodeResponse authCodeResponse;
        try
        {
            authCodeResponse = await _twitchAuthService.GetAccessTokenFromCodeAsync(clientId, clientSecret, code, redirectUri);
        }
        catch (Exception ex) when (ex is HttpRequestException || ex is ArgumentException)
        {
            return BadRequest(ex.Message);
        }

        TwitchUserCredentials credentials = new()
        {
            UserId = userIdValue,
            AccessToken = authCodeResponse.AccessToken,
            RefreshToken = authCodeResponse.RefreshToken,
            ExpiresIn = authCodeResponse.ExpiresIn
        };

        var response = await _twitchUserCredentialsRepository.CreateAsync(credentials);
        return Ok(response);
    }
}
