using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class MotdIrcMessage : IrcMessageWithCommandParameters<IrcMotdCommandParameters>
{
    public MotdIrcMessage(IrcSource prefix, IrcMotdCommandParameters parameters) : base(prefix, parameters)
    {
    }
}