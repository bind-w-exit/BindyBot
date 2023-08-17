using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class NickIrcMessage : IrcMessageWithCommandParameters<IrcNickCommandParameters, NickIrcMessage>
{
    public NickIrcMessage(IrcSource prefix, IrcNickCommandParameters parameters) : base(prefix, parameters)
    {
    }
}