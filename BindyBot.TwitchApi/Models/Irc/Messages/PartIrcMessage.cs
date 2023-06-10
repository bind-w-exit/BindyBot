using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class PartIrcMessage : IrcMessageWithCommandParameters<IrcPartCommandParameters>
{
    public PartIrcMessage(IrcSource prefix, IrcPartCommandParameters parameters) : base(prefix, parameters)
    {
    }
}