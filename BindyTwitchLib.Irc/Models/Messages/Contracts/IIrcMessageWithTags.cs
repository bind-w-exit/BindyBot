using BindyTwitchLib.Irc.Models.Tags.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public interface IIrcMessageWithTags<TIrcTags, TSelf>
    : IIrcMessage<TSelf>
    where TIrcTags : IIrcTags<TIrcTags>
    where TSelf : IIrcMessageWithTags<TIrcTags, TSelf>
{
    /// <summary>
    /// Tags are optional key-value pairs that provide additional metadata about the message.
    /// </summary>
    /// <remarks>
    /// Tags can convey information such as message timestamps, user badges, and more.
    /// </remarks>
    public TIrcTags? Tags { get; set; }
}