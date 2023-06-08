namespace BindyBot.TwitchApi.Models.Irc.Tags;

// https://dev.twitch.tv/docs/irc/tags/#roomstate-tags
// Prototype: @emote-only=<emote-only>;followers-only=<followers-only>;r9k=<r9k>;rituals=<rituals>;room-id=<room-id>;slow=<slow>;subs-only=<subs-only>
public class RoomStateTags : IIrcTags
{
    /// <summary>
    /// A Boolean value that determines whether the chat room allows only messages with emotes.
    /// </summary>
    public bool EmoteOnly { get; set; }

    /// <summary>
    /// An integer value that determines whether only followers can post messages in the chat room.
    /// The value indicates how long, in minutes, the user must have followed the broadcaster before posting chat messages.
    /// If the value is -1, the chat room is not restricted to followers only.
    /// </summary>
    public int FollowersOnly { get; set; }

    /// <summary>
    /// A Boolean value that determines whether a user’s messages must be unique.
    /// </summary>
    public bool R9K { get; set; }

    /// <summary>
    /// An ID that identifies the chat room (channel).
    /// </summary>
    public long RoomId { get; set; }

    /// <summary>
    /// An integer value that determines how long, in seconds, users must wait between sending messages.
    /// </summary>
    public int Slow { get; set; }

    /// <summary>
    /// A Boolean value that determines whether only subscribers and moderators can chat in the chat room.
    /// </summary>
    public bool SubsOnly { get; set; }
}