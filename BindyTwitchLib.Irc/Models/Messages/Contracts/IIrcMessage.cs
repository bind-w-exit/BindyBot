﻿namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public interface IIrcMessage<TSelf> : IParsable<TSelf>
    where TSelf : IIrcMessage<TSelf>
{
    /// <summary>
    /// The prefix component is optional and provides information about the source of the message.
    /// </summary>
    /// <remarks>
    /// It can represent EITHER the <b>server name</b> OR user information, including the <b>nickname</b>, <b>username</b>, and <b>hostname</b>.
    /// </remarks>
    public IrcSource Prefix { get; set; }

    // TODO: Add command?
}