using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class MotdStartIrcMessage : IrcMessageWithCommandParameters<IrcMotdStartCommandParameters>
{
    public MotdStartIrcMessage(IrcSource prefix, IrcMotdStartCommandParameters parameters) : base(prefix, parameters)
    {
    }
}