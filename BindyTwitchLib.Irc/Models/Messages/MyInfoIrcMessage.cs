using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class MyInfoIrcMessage : IrcMessageWithCommandParameters<IrcMyInfoCommandParameters>
{
    public MyInfoIrcMessage(IrcSource prefix, IrcMyInfoCommandParameters parameters) : base(prefix, parameters)
    {
    }
}