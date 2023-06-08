using System.ComponentModel;
using System.Drawing;

namespace BindyBot.TwitchApi.Models.Irc.Tags;

public class UserNoticeTags : IIrcTags
{
    /// <summary>
    /// Contains metadata related to the chat badges in the badges tag.
    /// Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
    /// </summary>
    public BadgeInfo BadgeInfo { get; set; }

    /// <summary>
    /// Comma-separated list of chat badges in the form, badge/version. For example, admin/1.
    /// </summary>
    public Badges Badges { get; set; }

    /// <summary>
    /// The color of the user’s name in the chat room. This is a hexadecimal RGB color code in the form, #RGB. This tag may be empty if it is never set.
    /// </summary>
    public Color? Color { get; set; }

    /// <summary>
    /// The user’s display name, escaped as described in the IRCv3 spec. This tag may be empty if it is never set.
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// A comma-delimited list of emotes and their positions in the message.
    /// Each emote is in the form, emote ID:start position-end position.
    /// The position indices are zero-based.
    /// </summary>
    public Emote[]? Emotes { get; set; }

    /// <summary>
    /// An ID that uniquely identifies the message.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The login name of the user whose action generated the message.
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// A Boolean value that determines whether the user is a moderator.
    /// </summary>
    public bool Mod { get; set; }

    /// <summary>
    /// The type of notice (not the ID).
    /// </summary>
    public UserNoticeMsgId MsgId { get; set; }

    public int RoomId { get; set; }

    public bool Subscriber { get; set; }

    /// <summary>
    /// The message Twitch shows in the chat room for this notice.
    /// </summary>
    public string SystemMsg { get; set; }

    /// <summary>
    /// The UNIX timestamp.
    /// </summary>
    public long TmiSentTs { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether the user has site-wide commercial free mode enabled.
    /// </summary>
    public bool Turbo { get; set; }

    public uint UserId { get; set; }
}

public enum UserNoticeMsgId
{
    [Description("sub")]
    Sub,

    [Description("resub")]
    Resub,

    [Description("subgift")]
    SubGift,

    [Description("submysterygift")]
    SubMysteryGift,

    [Description("giftpaidupgrade")]
    GiftPaidUpgrade,

    [Description("rewardgift")]
    RewardGift,

    [Description("anongiftpaidupgrade")]
    AnonGiftPaidUpgrade,

    [Description("raid")]
    Raid,

    [Description("unraid")]
    Unraid,

    [Description("ritual")]
    Ritual,

    [Description("bitsbadgetier")]
    BitsBadgetier
}