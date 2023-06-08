using BindyBot.TwitchApi.Helpers;
using System.Drawing;

namespace BindyBot.TwitchApi.Models.Irc.Tags;

// https://dev.twitch.tv/docs/irc/tags/#privmsg-tags
// Prototype: @badge-info=<badge-info>;badges=<badges>;bits=<bits>client-nonce=<nonce>;color=<color>;display-name=<display-name>;emotes=<emotes>;first-msg=<first-msg>;flags=<flags>;id=<msg-id>;mod=<mod>;room-id=<room-id>;subscriber=<subscriber>;tmi-sent-ts=<timestamp>;turbo=<turbo>;user-id=<user-id>;user-type=<user-type>;reply-parent-msg-id=<reply-parent-msg-id>;reply-parent-user-id=<reply-parent-user-id>;reply-parent-user-login=<reply-parent-user-login>;reply-parent-display-name=<reply-parent-display-name>;reply-parent-msg-body=<reply-parent-msg-body>;vip=<vip>
public class PrivMsgTags : IIrcTags
{
    /// <summary>
    /// Contains metadata related to the chat badges in the badges tag.
    /// Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
    /// </summary>
    [IrcTag("badge-info")]
    public BadgeInfo BadgeInfo { get; set; }

    /// <summary>
    /// Comma-separated list of chat badges in the form, badge/version. For example, admin/1.
    /// </summary>
    [IrcTag("badges")]
    public Badges Badges { get; set; }

    /// <summary>
    /// The amount of Bits the user cheered.
    /// </summary>
    [IrcTag("bits")]
    public uint Bits { get; set; }

    /// <summary>
    /// The color of the user’s name in the chat room. This is a hexadecimal RGB color code in the form, #RGB. This tag may be empty if it is never set.
    /// </summary>
    [IrcTag("color")]
    public Color? Color { get; set; }

    /// <summary>
    /// The user’s display name, escaped as described in the IRCv3 spec. This tag may be empty if it is never set.
    /// </summary>
    [IrcTag("display-name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// A comma-delimited list of emotes and their positions in the message.
    /// Each emote is in the form, emote ID:start position-end position.
    /// The position indices are zero-based.
    /// </summary>
    [IrcTag("emotes")]
    public Emote[]? Emotes { get; set; }

    /// <summary>
    /// An ID that uniquely identifies the message.
    /// </summary>
    [IrcTag("id")]
    public int Id { get; set; }

    /// <summary>
    /// A Boolean value that determines whether the user is a moderator.
    /// </summary>
    [IrcTag("mod")]
    public bool Mod { get; set; }

    /// <summary>
    /// An ID that uniquely identifies the parent message that this message is replying to. The message does not include this tag if this message is not a reply.
    /// </summary>
    [IrcTag("reply-parent-msg-id")]
    public int ReplyParentMsgId { get; set; }

    /// <summary>
    /// An ID that identifies the sender of the parent message. The message does not include this tag if this message is not a reply.
    /// </summary>
    [IrcTag("reply-parent-user-id")]
    public int ReplyParentUserId { get; set; }

    /// <summary>
    /// The login name of the sender of the parent message. The message does not include this tag if this message is not a reply.
    /// </summary>
    [IrcTag("reply-parent-user-login")]
    public string? ReplyParentUserLogin { get; set; }

    /// <summary>
    /// The display name of the sender of the parent message. The message does not include this tag if this message is not a reply.
    /// </summary>
    [IrcTag("reply-parent-display-name")]
    public string? ReplyParentDisplayName { get; set; }

    /// <summary>
    /// The text of the parent message. The message does not include this tag if this message is not a reply.
    /// </summary>
    [IrcTag("reply-parent-msg-body")]
    public string? ReplyParentMsgBody { get; set;}

    /// <summary>
    /// An ID that identifies the chat room (channel).
    /// </summary>
    [IrcTag("room-id")]
    public long? RoomId { get; set; }

    /// <summary>
    /// A Boolean value that determines whether the user is a subscriber.
    /// </summary>
    [IrcTag("subscriber")]
    public bool Subscriber { get; set; }

    /// <summary>
    /// The UNIX timestamp.
    /// </summary>
    [IrcTag("tmi-sent-ts")]
    public long TmiSentTs { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether the user has site-wide commercial free mode enabled.
    /// </summary>
    [IrcTag("turbo")]
    public bool Turbo { get; set; }

    [IrcTag("user-id")]
    public uint UserId { get; set; }

    [IrcTag("user-type")]
    public UserType UserType { get; set; }

    /// <summary>
    ///  Boolean value that determines whether the user that sent the chat is a VIP.
    ///  The message includes this tag if the user is a VIP;
    ///  otherwise, the message doesn’t include this tag (check for the presence of the tag instead of whether the tag is set to true or false).
    /// </summary>
    [IrcTag("vip")]
    public bool Vip { get; set; }
}