using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class HostTargetIrcMessage : IrcMessageWithCommandParameters<IrcHostTargetCommandParameters>
{
    public HostTargetIrcMessage(IrcSource prefix, IrcHostTargetCommandParameters parameters) : base(prefix, parameters)
    {
    }
}