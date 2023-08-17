using BindyTwitchLib.Irc.Helpers;
using BindyTwitchLib.Irc.Models.Tags.Contracts;

namespace BindyTwitchLib.Irc.Models.Tags;

// https://dev.twitch.tv/docs/irc/tags/#privmsg-tags
public partial class PrivMsgClientTags
{
    /// <summary>
    /// An ID that uniquely identifies the parent message that this message is replying to.
    /// </summary>
    [IrcTag("reply-parent-msg-id")]
    public Guid ReplyParentMsgId { get; set; }
}

public partial class PrivMsgClientTags : IrcTags<PrivMsgClientTags>
{
    protected override PrivMsgClientTags ParseFromDictionary(Dictionary<string, string> tags)
    {
        throw new NotImplementedException();
    }
}