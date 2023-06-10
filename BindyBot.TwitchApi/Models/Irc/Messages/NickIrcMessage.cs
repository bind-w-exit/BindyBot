using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class NickIrcMessage : IrcMessageWithCommandParameters<IrcNickCommandParameters>
{
    public NickIrcMessage(IrcSource prefix, IrcNickCommandParameters parameters) : base(prefix, parameters)
    {
    }
}