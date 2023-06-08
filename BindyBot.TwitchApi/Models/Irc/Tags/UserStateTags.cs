using BindyBot.TwitchApi.Helpers;
using System.Drawing;

namespace BindyBot.TwitchApi.Models.Irc.Tags;

// https://dev.twitch.tv/docs/irc/tags/#userstate-tags
// Prototype: @badge-info=<badge-info>;badges=<badges>;color=<color>;display-name=<display-name>;emote-sets=<emote-sets>;id=<id>;mod=<mod>;subscriber=<subscriber>;turbo=<turbo>;user-type=<user-type>
public class UserStateTags : IIrcTags
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
    /// A comma-delimited list of IDs that identify the emote sets that the user has access to.
    /// Is always set to at least zero (0). To access the emotes in the set, use the Get Emote Sets API.
    /// </summary>
    [IrcTag("emote-sets")]
    public int[] EmoteSets { get; set; }

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

    [IrcTag("subscriber")]
    public bool Subscriber { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether the user has site-wide commercial free mode enabled.
    /// </summary>
    [IrcTag("turbo")]
    public bool Turbo { get; set; }

    [IrcTag("user-type")]
    public UserType UserType { get; set; }
}
