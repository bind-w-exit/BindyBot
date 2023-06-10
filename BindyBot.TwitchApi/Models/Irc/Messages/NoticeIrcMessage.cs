using BindyBot.TwitchApi.Models.Irc.Contracts;
using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class NoticeIrcMessage : IrcMessageWithTagsAndCommandParameters<NoticeTags, IrcNoticeCommandParameters>
{
    public NoticeIrcMessage(NoticeTags? tags, IrcSource prefix, IrcNoticeCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}