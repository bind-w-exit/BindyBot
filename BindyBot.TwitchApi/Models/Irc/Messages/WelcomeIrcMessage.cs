using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class WelcomeIrcMessage : IrcMessageWithCommandParameters<IrcWelcomeCommandParameters>
{
    public WelcomeIrcMessage(IrcSource prefix, IrcWelcomeCommandParameters parameters) : base(prefix, parameters)
    {
    }
}