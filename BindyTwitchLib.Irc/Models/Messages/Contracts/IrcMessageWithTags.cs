using BindyTwitchLib.Irc.Models.Tags.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public abstract class IrcMessageWithTags<TIrcTags, TSelf>
    : IIrcMessageWithTags<TIrcTags, TSelf>  //: IrcMessage<TSelf>
    where TIrcTags : IIrcTags<TIrcTags>
    where TSelf : IrcMessageWithTags<TIrcTags, TSelf>
{
    public TIrcTags? Tags { get; set; }

    public IrcSource Prefix { get; set; }

    public IrcMessageWithTags(TIrcTags? tags, IrcSource prefix)
    {
        Tags = tags;
        Prefix = prefix;
    }

    public static TSelf Parse(string s, IFormatProvider? provider)
    {
        //Tags = TIrcTags.Parse(message, null);
        //return base.Parse(message);
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result)
    {
        throw new NotImplementedException();
    }
}