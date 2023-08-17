using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class PassIrcMessage : IrcMessageWithCommandParameters<IrcPassCommandParameters, PassIrcMessage>
{
    public PassIrcMessage(IrcSource prefix, IrcPassCommandParameters parameters) : base(prefix, parameters)
    {
    }
}