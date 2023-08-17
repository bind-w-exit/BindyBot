namespace BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

public interface IIrcCommandParameters<TSelf> : IParsable<TSelf>
    where TSelf : IIrcCommandParameters<TSelf>
{
}