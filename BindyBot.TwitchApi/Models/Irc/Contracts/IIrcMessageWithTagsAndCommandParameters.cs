using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Contracts;

public interface IIrcMessageWithTagsAndCommandParameters<TIrcTags, TIrcCommandParameters>
    : IIrcMessageWithTags<TIrcTags>, IIrcMessageWithCommandParameters<TIrcCommandParameters>
    where TIrcTags : IIrcTags
    where TIrcCommandParameters : IIrcCommandParameters
{
}