using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class NamReplyIrcMessage : IrcMessageWithCommandParameters<IrcNamReplyCommandParameters>
{
    public NamReplyIrcMessage(IrcSource prefix, IrcNamReplyCommandParameters parameters) : base(prefix, parameters)
    {
    }
}