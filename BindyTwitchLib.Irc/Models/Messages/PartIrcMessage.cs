using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class PartIrcMessage : IrcMessageWithCommandParameters<IrcPartCommandParameters>
{
    public PartIrcMessage(IrcSource prefix, IrcPartCommandParameters parameters) : base(prefix, parameters)
    {
    }
}