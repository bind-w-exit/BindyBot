using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class MotdStartIrcMessage : IrcMessageWithCommandParameters<IrcMotdStartCommandParameters>
{
    public MotdStartIrcMessage(IrcSource prefix, IrcMotdStartCommandParameters parameters) : base(prefix, parameters)
    {
    }
}