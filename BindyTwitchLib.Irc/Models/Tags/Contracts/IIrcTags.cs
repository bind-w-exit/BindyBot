namespace BindyTwitchLib.Irc.Models.Tags.Contracts;

public interface IIrcTags<TSelf> : IParsable<TSelf>
    where TSelf : IIrcTags<TSelf>
{
}