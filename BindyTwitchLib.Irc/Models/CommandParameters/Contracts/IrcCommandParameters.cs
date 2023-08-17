using System.Diagnostics.CodeAnalysis;

namespace BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

public abstract class IrcCommandParameters<TSelf> : IIrcCommandParameters<TSelf>
    where TSelf : IrcCommandParameters<TSelf>, new()
{
    public static TSelf Parse(string s, IFormatProvider? provider)
    {
        // TODO: Split a string into an array
        throw new NotImplementedException();
        //var tagInstance = new TSelf();
        //tagInstance.ParseFromArray();
        //return tagInstance;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result)
    {
        throw new NotImplementedException();
    }

    protected abstract TSelf ParseFromArray(string[] parameters);
}