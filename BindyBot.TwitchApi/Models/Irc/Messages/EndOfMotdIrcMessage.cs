using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class EndOfMotdIrcMessage : IrcMessageWithCommandParameters<IrcEndOfMotdCommandParameters>
{
    public EndOfMotdIrcMessage(IrcSource prefix, IrcEndOfMotdCommandParameters parameters) : base(prefix, parameters)
    {
    }
}