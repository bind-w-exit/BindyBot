using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class ReconnectIrcMessage : IIrcMessage
{
    public IrcSource Prefix { get; set; }

    public ReconnectIrcMessage(IrcSource prefix)
    {
        Prefix = prefix;
    }
}