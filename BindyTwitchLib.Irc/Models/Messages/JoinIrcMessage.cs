using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class JoinIrcMessage : IrcMessageWithCommandParameters<IrcJoinCommandParameters>
{
    public JoinIrcMessage(IrcSource prefix, IrcJoinCommandParameters parameters) : base(prefix, parameters)
    {
    }
}