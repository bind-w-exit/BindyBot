using BindyTwitchLib.Irc.Models.Tags.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public abstract class IrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters>
    : IIrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters>
    where TIrcTags : IIrcTags<TIrcTags>
    where TIrcCommandParameters : IIrcCommandParameters
{
    public TIrcTags? Tags { get; set; }

    public IrcSource Prefix { get; set; }

    public TIrcCommandParameters Parameters { get; set; }

    public IrcMessageWithTagsAndCommandParameters(TIrcTags? tags, IrcSource prefix, TIrcCommandParameters parameters)
    {
        Tags = tags;
        Prefix = prefix;
        Parameters = parameters;
    }
}