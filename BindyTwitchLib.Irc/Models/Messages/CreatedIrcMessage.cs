using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class CreatedIrcMessage : IrcMessageWithCommandParameters<IrcCreatedCommandParameters, CreatedIrcMessage>
{
    public CreatedIrcMessage(IrcSource prefix, IrcCreatedCommandParameters parameters) : base(prefix, parameters)
    {
    }
}