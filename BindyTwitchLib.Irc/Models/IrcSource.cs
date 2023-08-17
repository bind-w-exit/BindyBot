﻿using System.Diagnostics.CodeAnalysis;

namespace BindyTwitchLib.Irc.Models;

/// <summary>
/// Represents the prefix component of IRCv3 messages.
/// </summary>
/// <remarks>
/// <b>EITHER</b> <seealso cref="ServerName">ServerName</seealso> <b>OR</b> the combination of
/// <seealso cref="Nickname">Nickname</seealso>, <seealso cref="User">Username</seealso>,
/// and <seealso cref="Host">Hostname</seealso> will be set, not both.
/// </remarks>
public partial class IrcSource
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

public partial class IrcSource : IParsable<IrcSource>
{
    public static IrcSource Parse(string s, IFormatProvider? provider)
    {
        return ParsePrefixSwitch(s);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out IrcSource result)
    {
        throw new NotImplementedException();
    }

    // Source format
    // <servername> / ( <nickname> [ "!" <user> ][ "@" <host> ] )
    //private static IrcSource ParsePrefix(ReadOnlySpan<char> rawPrefix)
    //{
    //    if (!rawPrefix.StartsWithChar(':'))
    //        throw new ArgumentException("Invalid prefix format.");

    //    var userIndex = rawPrefix.IndexOf('!');
    //    var hostIndex = rawPrefix.IndexOf('@');

    //    if (userIndex != -1 && hostIndex != -1)  // nickname with user and host
    //    {
    //        string nickname = rawPrefix[1..(userIndex - 1)].ToString();
    //        string user = rawPrefix[(userIndex + 1)..(hostIndex - 1)].ToString();
    //        string host = rawPrefix[(hostIndex + 1)..].ToString();

    //        return new IrcSource(nickname, user, host);
    //    }
    //    else if (userIndex != -1) // nickname with user
    //    {
    //        string nickname = rawPrefix[1..(userIndex - 1)].ToString();
    //        string user = rawPrefix[(userIndex + 1)..].ToString();

    //        return new IrcSource(nickname, user, null);
    //    }
    //    else if (hostIndex != -1) // nickname with host
    //    {
    //        string nickname = rawPrefix[1..(hostIndex - 1)].ToString();
    //        string host = rawPrefix[(hostIndex + 1)..].ToString();

    //        return new IrcSource(nickname, null, host);
    //    }
    //    else // servername
    //    {
    //        return new IrcSource(rawPrefix[1..].ToString());
    //    }
    //}

    private static IrcSource ParsePrefixSwitch(string rawPrefix)
    {
        if (!rawPrefix.StartsWith(':'))
            throw new ArgumentException("Invalid prefix format.");

        var userIndex = rawPrefix.IndexOf('!');
        var hostIndex = rawPrefix.IndexOf('@');

        switch ((userIndex != -1, hostIndex != -1))
        {
            case (true, true): // nickname with user and host
                string nickname1 = rawPrefix.Substring(1, userIndex - 1);
                string user1 = rawPrefix.Substring(userIndex + 1, hostIndex - userIndex - 1);
                string host1 = rawPrefix.Substring(hostIndex + 1);

                return new IrcSource(nickname1, user1, host1);

            case (true, false): // nickname with user
                string nickname2 = rawPrefix.Substring(1, userIndex - 1);
                string user2 = rawPrefix.Substring(userIndex + 1);

                return new IrcSource(nickname2, user2, null);

            case (false, true): // nickname with host
                string nickname3 = rawPrefix.Substring(1, hostIndex - 1);
                string host3 = rawPrefix.Substring(hostIndex + 1);

                return new IrcSource(nickname3, null, host3);

            default: // servername
                return new IrcSource(rawPrefix.Substring(1));
        }
    }
}