using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class UnknownCommandIrcMessage : IrcMessageWithCommandParameters<IrcUnknownCommandCommandParameters, UnknownCommandIrcMessage>
{
    public UnknownCommandIrcMessage(IrcSource prefix, IrcUnknownCommandCommandParameters parameters) : base(prefix, parameters)
    {
    }
}