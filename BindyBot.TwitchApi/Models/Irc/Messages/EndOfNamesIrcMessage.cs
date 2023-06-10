using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class EndOfNamesIrcMessage : IrcMessageWithCommandParameters<IrcEndOfNamesCommandParameters>
{
    public EndOfNamesIrcMessage(IrcSource prefix, IrcEndOfNamesCommandParameters parameters) : base(prefix, parameters)
    {
    }
}