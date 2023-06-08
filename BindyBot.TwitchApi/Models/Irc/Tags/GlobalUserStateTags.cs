using System.Drawing;

namespace BindyBot.TwitchApi.Models.Irc.Tags;

// https://dev.twitch.tv/docs/irc/tags/#globaluserstate-tags
// Prototype: @badge-info=<badge-info>;badges=<badges>;color=<color>;display-name=<display-name>;emote-sets=<emote-sets>;turbo=<turbo>;user-id=<user-id>;user-type=<user-type>
public class GlobalUserStateTags : IIrcTags
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
    /// A comma-delimited list of IDs that identify the emote sets that the user has access to.
    /// Is always set to at least zero (0). To access the emotes in the set, use the Get Emote Sets API.
    /// </summary>
    public int[] EmoteSets { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether the user has site-wide commercial free mode enabled.
    /// </summary>
    public bool Turbo { get; set; }

    public uint UserId { get; set; }

    public UserType UserType { get; set; }
}