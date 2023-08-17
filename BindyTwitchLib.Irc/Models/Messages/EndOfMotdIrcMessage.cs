using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class EndOfMotdIrcMessage : IrcMessageWithCommandParameters<IrcEndOfMotdCommandParameters, EndOfMotdIrcMessage>
{
    public EndOfMotdIrcMessage(IrcSource prefix, IrcEndOfMotdCommandParameters parameters) : base(prefix, parameters)
    {
    }
}