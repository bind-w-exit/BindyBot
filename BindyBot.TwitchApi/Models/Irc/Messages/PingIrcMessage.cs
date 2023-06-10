using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class PingIrcMessage : IrcMessageWithCommandParameters<IrcPingCommandParameters>
{
    public PingIrcMessage(IrcSource prefix, IrcPingCommandParameters parameters) : base(prefix, parameters)
    {
    }
}