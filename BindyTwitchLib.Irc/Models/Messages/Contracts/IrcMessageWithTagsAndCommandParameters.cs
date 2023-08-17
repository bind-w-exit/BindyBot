using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;
using BindyTwitchLib.Irc.Models.Tags.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public abstract class IrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters, TSelf>
    : IIrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters, TSelf> //: IrcMessage<TSelf>
    where TIrcTags : IIrcTags<TIrcTags>
    where TIrcCommandParameters : IIrcCommandParameters<TIrcCommandParameters>
    where TSelf : IrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters, TSelf>
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

    public static TSelf Parse(string s, IFormatProvider? provider)
    {
        //Tags = TIrcTags.Parse(message, null);
        //Parameters = TIrcCommandParameters.Parse(message, null);
        //return base.Parse(message);
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result)
    {
        throw new NotImplementedException();
    }
}