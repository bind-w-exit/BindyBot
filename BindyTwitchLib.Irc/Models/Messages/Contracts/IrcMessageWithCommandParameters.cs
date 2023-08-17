using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public abstract class IrcMessageWithCommandParameters<TIrcCommandParameters, TSelf>
    : IIrcMessageWithCommandParameters<TIrcCommandParameters, TSelf> //: IrcMessage<TSelf>,
    where TIrcCommandParameters : IIrcCommandParameters<TIrcCommandParameters>
    where TSelf : IrcMessageWithCommandParameters<TIrcCommandParameters, TSelf>
{
    public IrcSource Prefix { get; set; }

    public TIrcCommandParameters Parameters { get; set; }

    public IrcMessageWithCommandParameters(IrcSource prefix, TIrcCommandParameters parameters)
    {
        Prefix = prefix;
        Parameters = parameters;
    }

    public static TSelf Parse(string s, IFormatProvider? provider)
    {
        //Parameters = TIrcCommandParameters.Parse(message, null);
        //return base.Parse(message);
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result)
    {
        throw new NotImplementedException();
    }
}