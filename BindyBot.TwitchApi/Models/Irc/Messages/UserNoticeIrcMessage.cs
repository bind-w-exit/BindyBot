using BindyBot.TwitchApi.Models.Irc.Contracts;
using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class UserNoticeIrcMessage : IrcMessageWithTagsAndCommandParameters<UserNoticeTags, IrcUserNoticeCommandParameters>
{
    public UserNoticeIrcMessage(UserNoticeTags? tags, IrcSource prefix, IrcUserNoticeCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}