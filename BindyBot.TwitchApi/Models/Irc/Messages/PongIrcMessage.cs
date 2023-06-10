using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class PongIrcMessage : IrcMessageWithCommandParameters<IrcPongCommandParameters>
{
    public PongIrcMessage(IrcSource prefix, IrcPongCommandParameters parameters) : base(prefix, parameters)
    {
    }
}