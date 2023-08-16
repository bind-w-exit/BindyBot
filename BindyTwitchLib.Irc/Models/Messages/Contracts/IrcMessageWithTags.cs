using BindyTwitchLib.Irc.Models.Tags.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public abstract class IrcMessageWithTags<TIrcTags>
    : IIrcMessageWithTags<TIrcTags>
    where TIrcTags : IIrcTags<TIrcTags>
{
    public TIrcTags? Tags { get; set; }

    public IrcSource Prefix { get; set; }

    public IrcMessageWithTags(TIrcTags? tags, IrcSource prefix)
    {
        Tags = tags;
        Prefix = prefix;
    }
}