using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class CreatedIrcMessage : IrcMessageWithCommandParameters<IrcCreatedCommandParameters>
{
    public CreatedIrcMessage(IrcSource prefix, IrcCreatedCommandParameters parameters) : base(prefix, parameters)
    {
    }
}