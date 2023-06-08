using BindyBot.TwitchApi.Helpers;
using System.Drawing;

namespace BindyBot.TwitchApi.Models.Irc.Tags;

// https://dev.twitch.tv/docs/irc/tags/#whisper-tags
// Prototype: @badges=<badges>;color=<color>;display-name=<display-name>;emotes=<emotes>;message-id=<msg-id>;thread-id=<thread-id>;turbo=<turbo>;user-id=<user-id>;user-type=<user-type>
public class WhisperTags : IIrcTags
{
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
    /// A comma-delimited list of emotes and their positions in the message.
    /// Each emote is in the form, emote ID:start position-end position.
    /// The position indices are zero-based.
    /// 
    /// NOTE It’s possible for the emotes flag’s value to be set to an action instead of identifying an emote. For example, \001ACTION barfs on the floor.\001.
    /// </summary>
    [IrcTag("emotes")]
    public Emote[]? Emotes { get; set; }

    /// <summary>
    /// An ID that uniquely identifies the whisper message.
    /// </summary>
    [IrcTag("message-id")]
    public long MessageId { get; set; }

    /// <summary>
    /// An ID that uniquely identifies the whisper thread. The ID is in the form, smaller-value-user-id_larger-value-user-id.
    /// </summary>
    [IrcTag("thread-id")]
    public int ThreadId { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether the user has site-wide commercial free mode enabled.
    /// </summary>
    [IrcTag("turbo")]
    public bool Turbo { get; set; }

    [IrcTag("user-id")]
    public uint UserId { get; set; }

    [IrcTag("user-type")]
    public UserType UserType { get; set; }
}
