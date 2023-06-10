using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Contracts;

public abstract class IrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters>
    : IIrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters>
    where TIrcTags : IIrcTags
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