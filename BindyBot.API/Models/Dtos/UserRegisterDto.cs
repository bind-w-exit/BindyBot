using BindyBot.Api.Enums;

namespace BindyBot.Api.Models.Dtos;

public record UserRegisterDto(string Username, string Password, Roles UserRole);