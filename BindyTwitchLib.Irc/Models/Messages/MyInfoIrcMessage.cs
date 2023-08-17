using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages;

public class MyInfoIrcMessage : IrcMessageWithCommandParameters<IrcMyInfoCommandParameters, MyInfoIrcMessage>
{
    public MyInfoIrcMessage(IrcSource prefix, IrcMyInfoCommandParameters parameters) : base(prefix, parameters)
    {
    }
}