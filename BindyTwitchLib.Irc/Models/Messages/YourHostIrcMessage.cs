using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class YourHostIrcMessage : IrcMessageWithCommandParameters<IrcYourHostCommandParameters>
{
    public YourHostIrcMessage(IrcSource prefix, IrcYourHostCommandParameters parameters) : base(prefix, parameters)
    {
    }
}