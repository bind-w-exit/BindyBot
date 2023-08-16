using BindyTwitchLib.Irc.Helpers;
using BindyTwitchLib.Irc.Models;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Parser;

public class TwitchIrcMessageParser
{
    public static IIrcMessage Parse(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentNullException(nameof(message));

        // The raw components of the IRC message.
        ReadOnlySpan<char> rawMessage = message.AsSpan();

        ReadOnlySpan<char> rawCommand;
        ReadOnlySpan<char> rawTags = ReadOnlySpan<char>.Empty;
        ReadOnlySpan<char> rawPrefix = ReadOnlySpan<char>.Empty;
        ReadOnlySpan<char> rawParameters = ReadOnlySpan<char>.Empty;

        if (rawMessage.StartsWith("@"))
        {
            int endIdx = rawMessage.IndexOf(' ');
            rawTags = rawMessage[1..endIdx];
            rawMessage = rawMessage[(endIdx + 1)..];
        }

        if (rawMessage.StartsWith(":"))
        {
            int endIdx = rawMessage.IndexOf(' ');
            rawPrefix = rawMessage[..endIdx];
            rawMessage = rawMessage[(endIdx + 1)..];
        }

        int parametersIdx = rawMessage.IndexOf(' ');
        if (parametersIdx != -1)
        {
            rawParameters = rawMessage[(parametersIdx + 1)..];
            rawMessage = rawMessage[..parametersIdx];
        }

        rawCommand = rawMessage;

        Console.WriteLine();
        Console.WriteLine($"RawTags: '{rawTags}'");
        Console.WriteLine($"RawPrefix: '{rawPrefix}'");
        Console.WriteLine($"RawCommand: '{rawCommand}'");
        Console.WriteLine($"RawParameters: '{rawParameters}'");
        Console.WriteLine();

        // Parse the components of the IRC message and assign them to properties
        // IIrcTags? tags = rawTags.IsEmpty ? null : ParseTags(rawTags.ToString());
        IrcSource? prefix = rawPrefix.IsEmpty ? null : ParsePrefixSwitch(rawPrefix.ToString());
        IIrcCommandParameters? parameters = rawParameters.IsEmpty ? null : ParseParameters(rawParameters.ToString());

        throw new NotImplementedException();
    }

    //public static IIrcTags ParseTags(string rawTags)
    //{
    //    throw new NotImplementedException();
    //}

    // Source format
    // <servername> / ( <nickname> [ "!" <user> ][ "@" <host> ] )
    public static IrcSource ParsePrefix(ReadOnlySpan<char> rawPrefix)
    {
        if (!rawPrefix.StartsWithChar(':'))
            throw new ArgumentException("Invalid prefix format.");

        var userIndex = rawPrefix.IndexOf('!');
        var hostIndex = rawPrefix.IndexOf('@');

        if (userIndex != -1 && hostIndex != -1)  // nickname with user and host
        {
            string nickname = rawPrefix[1..(userIndex - 1)].ToString();
            string user = rawPrefix[(userIndex + 1)..(hostIndex - 1)].ToString();
            string host = rawPrefix[(hostIndex + 1)..].ToString();

            return new IrcSource(nickname, user, host);
        }
        else if (userIndex != -1) // nickname with user
        {
            string nickname = rawPrefix[1..(userIndex - 1)].ToString();
            string user = rawPrefix[(userIndex + 1)..].ToString();

            return new IrcSource(nickname, user, null);
        }
        else if (hostIndex != -1) // nickname with host
        {
            string nickname = rawPrefix[1..(hostIndex - 1)].ToString();
            string host = rawPrefix[(hostIndex + 1)..].ToString();

            return new IrcSource(nickname, null, host);
        }
        else // servername
        {
            return new IrcSource(rawPrefix[1..].ToString());
        }
    }

    public static IrcSource ParsePrefixSwitch(string rawPrefix)
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

    private static IIrcCommandParameters? ParseParameters(string rawParameters)
    {
        throw new NotImplementedException();
    }
}