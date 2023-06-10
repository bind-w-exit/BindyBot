namespace BindyBot.TwitchApi.Models.Irc.Contracts;

public abstract class IrcMessageWithCommandParameters<TIrcCommandParameters>
    : IIrcMessage
    where TIrcCommandParameters : IIrcCommandParameters
{
    public IrcSource Prefix { get; set; }

    /// <summary>
    /// Parameters provide additional data associated with the command.
    /// </summary>
    /// <remarks>
    ///  The interpretation of parameters depends on the specific command being used.
    /// </remarks>
    public TIrcCommandParameters Parameters { get; set; }

    public IrcMessageWithCommandParameters(IrcSource prefix, TIrcCommandParameters parameters)
    {
        Prefix = prefix;
        Parameters = parameters;
    }
}