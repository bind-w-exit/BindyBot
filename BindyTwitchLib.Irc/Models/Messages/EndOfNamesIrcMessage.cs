using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class EndOfNamesIrcMessage : IrcMessageWithCommandParameters<IrcEndOfNamesCommandParameters, EndOfNamesIrcMessage>
{
    public EndOfNamesIrcMessage(IrcSource prefix, IrcEndOfNamesCommandParameters parameters) : base(prefix, parameters)
    {
    }
}