using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class WelcomeIrcMessage : IrcMessageWithCommandParameters<IrcWelcomeCommandParameters, WelcomeIrcMessage>
{
    public WelcomeIrcMessage(IrcSource prefix, IrcWelcomeCommandParameters parameters) : base(prefix, parameters)
    {
    }
}