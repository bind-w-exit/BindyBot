namespace BindyBot.TwitchApi.Models.Irc.Contracts;

public abstract class IrcMessageWithCommandParameters<TIrcCommandParameters>
    : IIrcMessageWithCommandParameters<TIrcCommandParameters>
    where TIrcCommandParameters : IIrcCommandParameters
{
    public IrcSource Prefix { get; set; }

    public TIrcCommandParameters Parameters { get; set; }

    public IrcMessageWithCommandParameters(IrcSource prefix, TIrcCommandParameters parameters)
    {
        Prefix = prefix;
        Parameters = parameters;
    }
}