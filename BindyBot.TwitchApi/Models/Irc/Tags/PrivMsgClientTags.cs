namespace BindyBot.TwitchApi.Models.Irc.Tags;

// https://dev.twitch.tv/docs/irc/tags/#privmsg-tags
public class PrivMsgClientTags : IIrcTags
{
    /// <summary>
    /// An ID that uniquely identifies the parent message that this message is replying to.
    /// </summary>
    public Guid ReplyParentMsgId { get; set; }
}