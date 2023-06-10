using BindyBot.TwitchApi.Models.Irc.Contracts;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class MyInfoIrcMessage : IrcMessageWithCommandParameters<IrcMyInfoCommandParameters>
{
    public MyInfoIrcMessage(IrcSource prefix, IrcMyInfoCommandParameters parameters) : base(prefix, parameters)
    {
    }
}