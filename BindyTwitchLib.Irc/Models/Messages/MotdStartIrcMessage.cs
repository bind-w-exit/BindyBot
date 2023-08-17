using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class MotdStartIrcMessage : IrcMessageWithCommandParameters<IrcMotdStartCommandParameters, MotdStartIrcMessage>
{
    public MotdStartIrcMessage(IrcSource prefix, IrcMotdStartCommandParameters parameters) : base(prefix, parameters)
    {
    }
}