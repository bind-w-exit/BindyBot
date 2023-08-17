using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class HostTargetIrcMessage : IrcMessageWithCommandParameters<IrcHostTargetCommandParameters, HostTargetIrcMessage>
{
    public HostTargetIrcMessage(IrcSource prefix, IrcHostTargetCommandParameters parameters) : base(prefix, parameters)
    {
    }
}