using BindyBot.TwitchApi.Models.Irc.Contracts;
using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class ClearMsgIrcMessage : IrcMessageWithTagsAndCommandParameters<ClearMsgTags, IrcClearMsgCommandParameters>
{
    public ClearMsgIrcMessage(ClearMsgTags? tags, IrcSource prefix, IrcClearMsgCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}