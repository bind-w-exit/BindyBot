namespace BindyTwitchLib.Irc.Models.Tags.Contracts;

public interface IIrcTag<TSelf> : IParsable<TSelf>
    where TSelf : IIrcTag<TSelf>?
{
}