using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class UnknownCommandIrcMessage : IrcMessageWithCommandParameters<IrcUnknownCommandCommandParameters>
{
    public UnknownCommandIrcMessage(IrcSource prefix, IrcUnknownCommandCommandParameters parameters) : base(prefix, parameters)
    {
    }
}