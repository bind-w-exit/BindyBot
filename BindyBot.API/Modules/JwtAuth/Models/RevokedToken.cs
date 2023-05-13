﻿namespace BindyBot.API.Modules.JwtAuth.Models;

public class RevokedToken
{
    public int Id { get; set; }
    public Guid Jti { get; set; }

    // TODO: Delete when expired
    public DateTime ExpiryDate { get; set; }
}