using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public interface IIrcMessageWithCommandParameters<TIrcCommandParameters, TSelf>
    : IIrcMessage<TSelf>
    where TIrcCommandParameters : IIrcCommandParameters<TIrcCommandParameters>
    where TSelf : IIrcMessageWithCommandParameters<TIrcCommandParameters, TSelf>
{
    /// <summary>
    /// Parameters provide additional data associated with the command.
    /// </summary>
    /// <remarks>
    ///  The interpretation of parameters depends on the specific command being used.
    /// </remarks>
    public TIrcCommandParameters Parameters { get; set; }
}