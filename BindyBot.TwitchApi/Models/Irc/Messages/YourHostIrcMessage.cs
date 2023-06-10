using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class YourHostIrcMessage : IrcMessageWithCommandParameters<IrcYourHostCommandParameters>
{
    public YourHostIrcMessage(IrcSource prefix, IrcYourHostCommandParameters parameters) : base(prefix, parameters)
    {
    }
}