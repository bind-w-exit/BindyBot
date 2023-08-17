using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class MotdIrcMessage : IrcMessageWithCommandParameters<IrcMotdCommandParameters, MotdIrcMessage>
{
    public MotdIrcMessage(IrcSource prefix, IrcMotdCommandParameters parameters) : base(prefix, parameters)
    {
    }
}