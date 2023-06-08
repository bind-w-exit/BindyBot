namespace BindyBot.TwitchApi.Models.Irc;

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
    RPL_NAMREPLY = 353,
    RPL_ENDOFNAMES = 366,
    ERR_UNKNOWNCOMMAND = 421,
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

public class CombinedIrcCommand
{
    public ushort Value { get; private set; }
    public bool IsIrcCommand { get; private set; }
    public bool IsNumericIrcCommand { get; private set; }
    public bool IsTwitchIrcCommand { get; private set; }

    public CombinedIrcCommand(Enum command)
    {
        Value = Convert.ToUInt16(command);
        SetCommandType(command);
    }

    private void SetCommandType(Enum command)
    {
        switch (command)
        {
            case IrcCommand:
                IsIrcCommand = true;
                break;

            case NumericIrcCommand:
                IsNumericIrcCommand = true;
                break;

            case TwitchIrcCommand:
                IsTwitchIrcCommand = true;
                break;

            default:
                throw new ArgumentException("Invalid command type");
        }
    }
}