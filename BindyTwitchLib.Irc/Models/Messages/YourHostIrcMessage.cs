using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class YourHostIrcMessage : IrcMessageWithCommandParameters<IrcYourHostCommandParameters, YourHostIrcMessage>
{
    public YourHostIrcMessage(IrcSource prefix, IrcYourHostCommandParameters parameters) : base(prefix, parameters)
    {
    }
}