﻿namespace BindyBot.TwitchApi.Models.Irc;

/// <summary>
/// Represents the prefix component of IRCv3 messages.
/// </summary>
/// <remarks>
/// <b>EITHER</b> <seealso cref="ServerName">ServerName</seealso> <b>OR</b> the combination of
/// <seealso cref="Nickname">Nickname</seealso>, <seealso cref="User">Username</seealso>,
/// and <seealso cref="Host">Hostname</seealso> will be set, not both.
/// </remarks>
public class IrcSource
{
    /// <summary>
    /// Gets the server name if the message is generated by a server.
    /// </summary>
    public string? ServerName { get; }

    /// <summary>
    /// Gets the nickname of the user who sent the message if the message is generated by a user.
    /// </summary>
    public string? Nickname { get; }

    /// <summary>
    /// Gets the username associated with the nickname (optional).
    /// </summary>
    public string? User { get; }

    /// <summary>
    /// Gets the hostname associated with the nickname (optional).
    /// </summary>
    public string? Host { get; }

    /// <summary>
    /// Gets a value indicating whether the prefix represents a server prefix.
    /// </summary>
    public bool IsServerPrefix => !string.IsNullOrEmpty(ServerName);

    /// <summary>
    /// Gets a value indicating whether the prefix represents a user prefix.
    /// </summary>
    public bool IsUserPrefix => !string.IsNullOrEmpty(Nickname);

    /// <summary>
    /// Represents the prefix with the server name.
    /// </summary>
    /// <param name="serverName">The server name.</param>
    public IrcSource(string serverName)
    {
        ServerName = serverName;
    }

    /// <summary>
    /// Represents the prefix with the nickname, username, and hostname.
    /// </summary>
    /// <param name="nickname">The nickname of the user.</param>
    /// <param name="username">The username associated with the nickname.</param>
    /// <param name="hostname">The hostname associated with the nickname.</param>
    public IrcSource(string nickname, string? user, string? host)
    {
        Nickname = nickname;
        User = user;
        Host = host;
    }
}