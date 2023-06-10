using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Contracts;

public abstract class IrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters>
    : IIrcMessage
    where TIrcTags : IIrcTags
    where TIrcCommandParameters : IIrcCommandParameters
{
    /// <summary>
    /// Tags are optional key-value pairs that provide additional metadata about the message.
    /// </summary>
    /// <remarks>
    /// Tags can convey information such as message timestamps, user badges, and more.
    /// </remarks>
    public TIrcTags? Tags { get; set; }

    public IrcSource Prefix { get; set; }

    /// <summary>
    /// Parameters provide additional data associated with the command.
    /// </summary>
    /// <remarks>
    ///  The interpretation of parameters depends on the specific command being used.
    /// </remarks>
    public TIrcCommandParameters Parameters { get; set; }

    public IrcMessageWithTagsAndCommandParameters(TIrcTags? tags, IrcSource prefix, TIrcCommandParameters parameters)
    {
        Tags = tags;
        Prefix = prefix;
        Parameters = parameters;
    }
}