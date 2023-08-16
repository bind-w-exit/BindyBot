using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class PassIrcMessage : IrcMessageWithCommandParameters<IrcPassCommandParameters>
{
    public PassIrcMessage(IrcSource prefix, IrcPassCommandParameters parameters) : base(prefix, parameters)
    {
    }
}