using System.Diagnostics.CodeAnalysis;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public abstract class IrcMessage<TSelf> : IIrcMessage<TSelf>
    where TSelf : IrcMessage<TSelf>
{
    public IrcSource Prefix { get; set; }

    public IrcMessage(IrcSource prefix)
    {
        Prefix = prefix;
    }

    public static TSelf Parse(string s, IFormatProvider? provider)
    {
        //Prefix = IrcSource.Parse(message, null);
        //return this;
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result)
    {
        throw new NotImplementedException();
    }
}