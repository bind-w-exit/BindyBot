using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class MotdIrcMessage : IrcMessageWithCommandParameters<IrcMotdCommandParameters>
{
    public MotdIrcMessage(IrcSource prefix, IrcMotdCommandParameters parameters) : base(prefix, parameters)
    {
    }
}