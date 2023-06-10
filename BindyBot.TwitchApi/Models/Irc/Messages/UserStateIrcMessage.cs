using BindyBot.TwitchApi.Models.Irc.Contracts;
using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class UserStateIrcMessage : IrcMessageWithTagsAndCommandParameters<UserStateTags, IrcUserStateCommandParameters>
{
    public UserStateIrcMessage(UserStateTags? tags, IrcSource prefix, IrcUserStateCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}