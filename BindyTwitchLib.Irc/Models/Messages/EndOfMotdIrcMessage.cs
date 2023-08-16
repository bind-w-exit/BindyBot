using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class EndOfMotdIrcMessage : IrcMessageWithCommandParameters<IrcEndOfMotdCommandParameters>
{
    public EndOfMotdIrcMessage(IrcSource prefix, IrcEndOfMotdCommandParameters parameters) : base(prefix, parameters)
    {
    }
}