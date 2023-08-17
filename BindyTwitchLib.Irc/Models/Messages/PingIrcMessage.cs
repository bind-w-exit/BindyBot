using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class PingIrcMessage : IrcMessageWithCommandParameters<IrcPingCommandParameters, PingIrcMessage>
{
    public PingIrcMessage(IrcSource prefix, IrcPingCommandParameters parameters) : base(prefix, parameters)
    {
    }
}