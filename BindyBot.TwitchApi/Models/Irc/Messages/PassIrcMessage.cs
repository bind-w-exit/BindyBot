using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class PassIrcMessage : IrcMessageWithCommandParameters<IrcPassCommandParameters>
{
    public PassIrcMessage(IrcSource prefix, IrcPassCommandParameters parameters) : base(prefix, parameters)
    {
    }
}