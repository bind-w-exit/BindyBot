using BindyTwitchLib.Irc.Models.Messages.Contracts;
using BindyTwitchLib.Irc.Models.Tags;

namespace BindyTwitchLib.Irc.Models.Messages;

public class NoticeIrcMessage : IrcMessageWithTagsAndCommandParameters<NoticeTags, IrcNoticeCommandParameters>
{
    public NoticeIrcMessage(NoticeTags? tags, IrcSource prefix, IrcNoticeCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}