namespace BindyTwitchLib.Irc.Models;

/// <summary>
/// Supported IRC messages
/// </summary>
public enum IrcCommand
{
    JOIN,
    NICK,
    NOTICE,
    PART,
    PASS,
    PING,
    PONG,
    PRIVMSG
}

/// <summary>
/// Supported numeric IRC messages
/// </summary>
public enum NumericIrcCommand
{
    RPL_WELCOME = 001,
    RPL_YOURHOST = 002,
    RPL_CREATED = 003,
    RPL_MYINFO = 004,
    RPL_NAMREPLY = 353,
    RPL_ENDOFNAMES = 366,
    RPL_MOTD = 372,
    RPL_MOTDSTART = 375,
    RPL_ENDOFMOTD = 376,
    ERR_UNKNOWNCOMMAND = 421
}

/// <summary>
/// Twitch-specific IRC messages
/// </summary>
public enum TwitchIrcCommand
{
    CLEARCHAT,
    CLEARMSG,
    GLOBALUSERSTATE, // No specific parameters needed
    HOSTTARGET,
    RECONNECT, // No specific parameters needed
    ROOMSTATE,
    USERNOTICE,
    USERSTATE,
    WHISPER
}