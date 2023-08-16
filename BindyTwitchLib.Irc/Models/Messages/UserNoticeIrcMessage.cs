using BindyTwitchLib.Irc.Models.Messages.Contracts;
using BindyTwitchLib.Irc.Models.Tags;

namespace BindyTwitchLib.Irc.Models.Messages;

public class UserNoticeIrcMessage : IrcMessageWithTagsAndCommandParameters<UserNoticeTags, IrcUserNoticeCommandParameters>
{
    public UserNoticeIrcMessage(UserNoticeTags? tags, IrcSource prefix, IrcUserNoticeCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}