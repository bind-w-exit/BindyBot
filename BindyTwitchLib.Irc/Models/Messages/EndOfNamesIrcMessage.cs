using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class EndOfNamesIrcMessage : IrcMessageWithCommandParameters<IrcEndOfNamesCommandParameters>
{
    public EndOfNamesIrcMessage(IrcSource prefix, IrcEndOfNamesCommandParameters parameters) : base(prefix, parameters)
    {
    }
}