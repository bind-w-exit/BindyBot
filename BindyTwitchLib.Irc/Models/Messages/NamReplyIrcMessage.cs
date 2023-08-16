using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class NamReplyIrcMessage : IrcMessageWithCommandParameters<IrcNamReplyCommandParameters>
{
    public NamReplyIrcMessage(IrcSource prefix, IrcNamReplyCommandParameters parameters) : base(prefix, parameters)
    {
    }
}