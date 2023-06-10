using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Contracts;

public abstract class IrcMessageWithTags<TIrcTags>
    : IIrcMessageWithTags<TIrcTags>
    where TIrcTags : IIrcTags
{
    public TIrcTags? Tags { get; set; }

    public IrcSource Prefix { get; set; }

    public IrcMessageWithTags(TIrcTags? tags, IrcSource prefix)
    {
        Tags = tags;
        Prefix = prefix;
    }
}