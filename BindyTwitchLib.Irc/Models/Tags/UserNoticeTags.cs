using BindyTwitchLib.Irc.Helpers;
using BindyTwitchLib.Irc.Models.Tags.Contracts;
using System.ComponentModel;
using System.Drawing;

namespace BindyTwitchLib.Irc.Models.Tags;

// https://dev.twitch.tv/docs/irc/tags/#usernotice-tags
// Prototype: @badge-info=<badge-info>;badges=<badges>;color=<color>;display-name=<display-name>;emotes=<emotes>;id=<id-of-msg>;login=<user>;mod=<mod>;msg-id=<msg-id>;room-id=<room-id>;subscriber=<subscriber>;system-msg=<system-msg>;tmi-sent-ts=<timestamp>;turbo=<turbo>;user-id=<user-id>;user-type=<user-type>
public class UserNoticeTags : IrcTags<UserNoticeTags>
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
    public List<string> Badges { get; set; }

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
    /// The login name of the user whose action generated the message.
    /// </summary>
    [IrcTag("login")]
    public string Login { get; set; }

    /// <summary>
    /// A Boolean value that determines whether the user is a moderator.
    /// </summary>
    [IrcTag("mod")]
    public bool Mod { get; set; }

    /// <summary>
    /// The type of notice (not the ID).
    /// </summary>
    [IrcTag("msg-id")]
    public UserNoticeMsgId MsgId { get; set; }

    [IrcTag("room-id")]
    public int RoomId { get; set; }

    [IrcTag("subscriber")]
    public bool Subscriber { get; set; }

    /// <summary>
    /// The message Twitch shows in the chat room for this notice.
    /// </summary>
    [IrcTag("system-msg")]
    public string SystemMsg { get; set; }

    /// <summary>
    /// The UNIX timestamp.
    /// </summary>
    [IrcTag("system-msg")]
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

    #region Only subscription- and raid-related notices include the following tags:

    /// <summary>
    /// Included only with sub and resub notices.
    /// The total number of months the user has subscribed.
    /// This is the same as msg-param-months but sent for different types of user notices.
    /// </summary>
    [IrcTag("msg-param-cumulative-months")]
    public int? MsgParamCumulativeMonths { get; set; }

    /// <summary>
    /// Included only with raid notices.
    /// The display name of the broadcaster raiding this channel.
    /// </summary>
    [IrcTag("msg-param-displayName")]
    public string? MsgParamDisplayName { get; set; }

    /// <summary>
    /// Included only with raid notices.
    /// The login name of the broadcaster raiding this channel.
    /// </summary>
    [IrcTag("msg-param-login")]
    public string? MsgParamLogin { get; set; }

    /// <summary>
    /// Included only with sub gift notices.
    /// The total number of months the user has subscribed.This is the same as msg-param-cumulative-months but sent for different types of user notices.
    /// </summary>
    [IrcTag("msg-param-months")]
    public int? MsgParamMonths { get; set; }

    /// <summary>
    /// Included only with anongiftpaidupgrade and giftpaidupgrade notices.
    /// The number of gifts the gifter has given during the promo indicated by msg-param-promo-name.
    /// </summary>
    [IrcTag("msg-param-promo-gift-total")]
    public int? MsgParamPromoGiftTotal { get; set; }

    /// <summary>
    /// Included only with anongiftpaidupgrade and giftpaidupgrade notices.
    /// The subscriptions promo, if any, that is ongoing(for example, Subtember 2018).
    /// </summary>
    [IrcTag("msg-param-promo-name")]
    public string? MsgParamPromoName { get; set; }

    /// <summary>
    /// Included only with subgift notices.
    /// The display name of the subscription gift recipient.
    /// </summary>
    [IrcTag("msg-param-recipient-display-name")]
    public string? MsgParamRecipientDisplayName { get; set; }

    /// <summary>
    /// Included only with subgift notices.
    /// The user ID of the subscription gift recipient.
    /// </summary>
    [IrcTag("msg-param-recipient-id")]
    public long? MsgParamRecipientId { get; set; }

    /// <summary>
    /// Included only with subgift notices.
    /// The user name of the subscription gift recipient.
    /// </summary>
    [IrcTag("msg-param-recipient-user-name")]
    public string? MsgParamRecipientUserName { get; set; }

    /// <summary>
    /// Included only with giftpaidupgrade notices.
    /// The login name of the user who gifted the subscription.
    /// </summary>
    [IrcTag("msg-param-sender-login")]
    public string? MsgParamSenderLogin { get; set; }

    /// <summary>
    /// Include only with giftpaidupgrade notices.
    /// The display name of the user who gifted the subscription.
    /// </summary>
    [IrcTag("msg-param-sender-name")]
    public string? MsgParamSenderName { get; set; }

    /// <summary>
    /// Included only with sub and resub notices.
    /// A Boolean value that indicates whether the user wants their streaks shared.
    /// </summary>
    [IrcTag("msg-param-should-share-streak")]
    public bool? MsgParamShouldShareStreak { get; set; }

    /// <summary>
    /// Included only with sub and resub notices.
    /// The number of consecutive months the user has subscribed.This is zero(0) if msg-param-should-share-streak is 0.
    /// </summary>
    [IrcTag("msg-param-streak-months")]
    public int? MsgParamStreakMonths { get; set; }

    /// <summary>
    /// Included only with sub, resub and subgift notices.
    /// </summary>
    [IrcTag("msg-param-sub-plan")]
    public SubPlan? MsgParamSubPlan { get; set; }

    /// <summary>
    /// Included only with sub, resub, and subgift notices.
    /// The display name of the subscription plan.This may be a default name or one created by the channel owner.
    /// </summary>
    [IrcTag("msg-param-sub-plan-name")]
    public string? MsgParamSubPlanName { get; set; }

    /// <summary>
    /// Included only with raid notices.
    /// The number of viewers raiding this channel from the broadcaster’s channel.
    /// </summary>
    [IrcTag("msg-param-viewerCount")]
    public int? MsgParamViewerCount { get; set; }

    /// <summary>
    /// Included only with ritual notices.
    /// The name of the ritual being celebrated.Possible values are: new_chatter.
    /// </summary>
    [IrcTag("msg-param-ritual-name")]
    public string? MsgParamRitualName { get; set; }

    /// <summary>
    /// Included only with bitsbadgetier notices.
    /// The tier of the Bits badge the user just earned.For example, 100, 1000, or 10000.
    /// </summary>
    [IrcTag("msg-param-threshold")]
    public int? MsgParamThreshold { get; set; }

    /// <summary>
    /// Included only with subgift notices.
    /// The number of months gifted as part of a single, multi-month gift.
    /// </summary>
    [IrcTag("msg-param-gift-months")]
    public int? MsgParamGiftMonths { get; set; }

    #endregion Only subscription- and raid-related notices include the following tags:

    protected override UserNoticeTags ParseFromDictionary(Dictionary<string, string> tags)
    {
        throw new NotImplementedException();
    }
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

public enum SubPlan
{
    // Amazon Prime subscription
    [Description("Prime")]
    Prime,

    // First level of paid subscription
    [Description("1000")]
    FirstLevel,

    // Second level of paid subscription
    [Description("2000")]
    SecondLevel,

    // Third level of paid subscription
    [Description("3000")]
    ThirdLevel
}