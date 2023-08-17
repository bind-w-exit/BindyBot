using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;
using BindyTwitchLib.Irc.Models.Tags;

namespace BindyTwitchLib.Irc.Models.Messages;

public class UserStateIrcMessage : IrcMessageWithTagsAndCommandParameters<UserStateTags, IrcUserStateCommandParameters, UserStateIrcMessage>
{
    public UserStateIrcMessage(UserStateTags? tags, IrcSource prefix, IrcUserStateCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}