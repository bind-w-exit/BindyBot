using BindyBot.API.Modules.JwtAuth.Models;

namespace BindyBot.API.Modules.JwtAuth.Dtos;

public record UserForRegisterDto(string Username, string Password, UserRole UserRole);