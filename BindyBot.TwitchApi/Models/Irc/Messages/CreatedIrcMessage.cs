using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class CreatedIrcMessage : IrcMessageWithCommandParameters<IrcCreatedCommandParameters>
{
    public CreatedIrcMessage(IrcSource prefix, IrcCreatedCommandParameters parameters) : base(prefix, parameters)
    {
    }
}