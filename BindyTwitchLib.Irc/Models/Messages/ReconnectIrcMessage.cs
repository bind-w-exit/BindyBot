using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class ReconnectIrcMessage : IIrcMessage
{
    public IrcSource Prefix { get; set; }

    public ReconnectIrcMessage(IrcSource prefix)
    {
        Prefix = prefix;
    }
}