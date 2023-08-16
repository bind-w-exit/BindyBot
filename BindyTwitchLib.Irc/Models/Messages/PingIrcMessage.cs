using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class PingIrcMessage : IrcMessageWithCommandParameters<IrcPingCommandParameters>
{
    public PingIrcMessage(IrcSource prefix, IrcPingCommandParameters parameters) : base(prefix, parameters)
    {
    }
}