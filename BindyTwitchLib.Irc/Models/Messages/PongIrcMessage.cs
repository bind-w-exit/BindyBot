using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class PongIrcMessage : IrcMessageWithCommandParameters<IrcPongCommandParameters, PongIrcMessage>
{
    public PongIrcMessage(IrcSource prefix, IrcPongCommandParameters parameters) : base(prefix, parameters)
    {
    }
}