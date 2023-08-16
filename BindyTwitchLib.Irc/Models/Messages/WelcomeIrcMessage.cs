using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class WelcomeIrcMessage : IrcMessageWithCommandParameters<IrcWelcomeCommandParameters>
{
    public WelcomeIrcMessage(IrcSource prefix, IrcWelcomeCommandParameters parameters) : base(prefix, parameters)
    {
    }
}