using BindyTwitchLib.Irc.Models.Tags.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public interface IIrcMessageWithTags<TIrcTags>
    : IIrcMessage
    where TIrcTags : IIrcTags<TIrcTags>
{
    /// <summary>
    /// Tags are optional key-value pairs that provide additional metadata about the message.
    /// </summary>
    /// <remarks>
    /// Tags can convey information such as message timestamps, user badges, and more.
    /// </remarks>
    public TIrcTags? Tags { get; set; }
}