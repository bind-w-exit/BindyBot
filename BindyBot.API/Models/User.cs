﻿using BindyBot.Api.Enums;

namespace BindyBot.Api.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public Roles UserRole { get; set; }

    public User(string username, byte[] passwordHash, byte[] passwordSalt, Roles userRole)
    {
        Username = username;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        UserRole = userRole;
    }
}