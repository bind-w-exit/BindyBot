using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class UnknownCommandIrcMessage : IrcMessageWithCommandParameters<IrcUnknownCommandCommandParameters>
{
    public UnknownCommandIrcMessage(IrcSource prefix, IrcUnknownCommandCommandParameters parameters) : base(prefix, parameters)
    {
    }
}