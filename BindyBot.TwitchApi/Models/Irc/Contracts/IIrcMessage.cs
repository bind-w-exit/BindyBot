namespace BindyBot.TwitchApi.Models.Irc.Contracts;

public interface IIrcMessage
{
    /// <summary>
    /// Tags are optional key-value pairs that provide additional metadata about the message.
    /// </summary>
    /// <remarks>
    /// Tags can convey information such as message timestamps, user badges, and more.
    /// </remarks>
    // public TIrcTags? Tags { get; set; }

    /// <summary>
    /// The prefix component is optional and provides information about the source of the message.
    /// </summary>
    /// <remarks>
    /// It can represent EITHER the <b>server name</b> OR user information, including the <b>nickname</b>, <b>username</b>, and <b>hostname</b>.
    /// </remarks>
    public IrcSource Prefix { get; set; }

    // TODO: Add command?
    /// <summary>
    /// The command represents the type of message being sent or received.
    /// </summary>
    /// <remarks>
    /// It indicates the action or operation being performed, such as sending messages, joining a channel, or checking connectivity.
    /// </remarks>
    // public CombinedIrcCommand Command { get; set; }

    /// <summary>
    /// Parameters provide additional data associated with the command.
    /// </summary>
    /// <remarks>
    ///  The interpretation of parameters depends on the specific command being used.
    /// </remarks>
    // public TIrcCommandParameters Parameters { get; set; }
}