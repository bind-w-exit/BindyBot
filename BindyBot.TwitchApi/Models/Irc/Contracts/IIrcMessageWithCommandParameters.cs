namespace BindyBot.TwitchApi.Models.Irc.Contracts;

public interface IIrcMessageWithCommandParameters<TIrcCommandParameters>
    : IIrcMessage
    where TIrcCommandParameters : IIrcCommandParameters
{
    /// <summary>
    /// Parameters provide additional data associated with the command.
    /// </summary>
    /// <remarks>
    ///  The interpretation of parameters depends on the specific command being used.
    /// </remarks>
    public TIrcCommandParameters Parameters { get; set; }
}