using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class JoinIrcMessage : IrcMessageWithCommandParameters<IrcJoinCommandParameters>
{
    public JoinIrcMessage(IrcSource prefix, IrcJoinCommandParameters parameters) : base(prefix, parameters)
    {
    }
}