using BindyBot.TwitchApi.Helpers;

namespace BindyBot.TwitchApi.Models.Irc.Tags;

// https://dev.twitch.tv/docs/irc/tags/#clearmsg-tags
// Prototype: @login=<login>;room-id=<room-id>;target-msg-id=<target-msg-id>;tmi-sent-ts=<timestamp>
public class ClearMsgTags : IIrcTags
{
    /// <summary>
    /// The name of the user who sent the message.
    /// </summary>
    [IrcTag("login")]
    public string Login { get; set; }

    /// <summary>
    /// Optional. The ID of the channel (chat room) where the message was removed from.
    /// </summary>
    [IrcTag("room-id")]
    public long? RoomId { get; set; }

    /// <summary>
    /// A UUID that identifies the message that was removed.
    /// </summary>
    [IrcTag("target-msg-id")]
    public long TargetMsgId { get; set; }

    /// <summary>
    /// The UNIX timestamp.
    /// </summary>
    [IrcTag("tmi-sent-ts")]
    public long TmiSentTs { get; set; }
}