using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class ReconnectIrcMessage : IrcMessage<ReconnectIrcMessage>
{
    public ReconnectIrcMessage(IrcSource prefix) : base(prefix)
    {
    }
}