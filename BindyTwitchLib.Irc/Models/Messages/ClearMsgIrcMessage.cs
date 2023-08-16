using BindyTwitchLib.Irc.Models.Messages.Contracts;
using BindyTwitchLib.Irc.Models.Tags;

namespace BindyTwitchLib.Irc.Models.Messages;

public class ClearMsgIrcMessage : IrcMessageWithTagsAndCommandParameters<ClearMsgTags, IrcClearMsgCommandParameters>
{
    public ClearMsgIrcMessage(ClearMsgTags? tags, IrcSource prefix, IrcClearMsgCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}