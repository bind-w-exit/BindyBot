using BindyTwitchLib.Irc.Models.Tags.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public interface IIrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters>
    : IIrcMessageWithTags<TIrcTags>, IIrcMessageWithCommandParameters<TIrcCommandParameters>
    where TIrcTags : IIrcTags<TIrcTags>
    where TIrcCommandParameters : IIrcCommandParameters
{
}