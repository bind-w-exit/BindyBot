namespace BindyBot.TwitchApi.Models.Irc.Tags;

// https://dev.twitch.tv/docs/irc/tags/#clearchat-tags
// Prototype: @ban-duration=<duration>;room-id=<room-id>;target-user-id=<user-id>;tmi-sent-ts=<timestamp>
public class ClearChatTags : IIrcTags
{
    /// <summary>
    /// Optional. The message includes this tag if the user was put in a timeout. The tag contains the duration of the timeout, in seconds.
    /// </summary>
    public long? BanDuration { get; set; }

    /// <summary>
    /// The ID of the channel where the messages were removed from.
    /// </summary>
    public long RoomId { get; set; }

    /// <summary>
    /// Optional. The ID of the user that was banned or put in a timeout. The user was banned if the message doesn’t include the <see cref="BanDuration"/> tag.
    /// </summary>
    public long? TargetUserId { get; set; }

    /// <summary>
    /// The UNIX timestamp.
    /// </summary>
    public long TmiSentTs { get; set; }
}