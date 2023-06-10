using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class HostTargetIrcMessage : IrcMessageWithCommandParameters<IrcHostTargetCommandParameters>
{
    public HostTargetIrcMessage(IrcSource prefix, IrcHostTargetCommandParameters parameters) : base(prefix, parameters)
    {
    }
}