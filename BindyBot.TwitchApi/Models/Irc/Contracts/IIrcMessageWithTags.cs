using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Contracts;

public interface IIrcMessageWithTags<TIrcTags>
    : IIrcMessage
    where TIrcTags : IIrcTags
{
    /// <summary>
    /// Tags are optional key-value pairs that provide additional metadata about the message.
    /// </summary>
    /// <remarks>
    /// Tags can convey information such as message timestamps, user badges, and more.
    /// </remarks>
    public TIrcTags? Tags { get; set; }
}
