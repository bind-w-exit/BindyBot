using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;
using BindyTwitchLib.Irc.Models.Tags.Contracts;

namespace BindyTwitchLib.Irc.Models.Messages.Contracts;

public interface IIrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters, TSelf>
    : IIrcMessageWithTags<TIrcTags, TSelf>, IIrcMessageWithCommandParameters<TIrcCommandParameters, TSelf>
    where TIrcTags : IIrcTags<TIrcTags>
    where TIrcCommandParameters : IIrcCommandParameters<TIrcCommandParameters>
    where TSelf : IIrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters, TSelf>
{
}