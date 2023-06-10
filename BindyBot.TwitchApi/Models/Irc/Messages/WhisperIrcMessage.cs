using BindyBot.TwitchApi.Models.Irc.Contracts;
using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class WhisperIrcMessage : IrcMessageWithTagsAndCommandParameters<WhisperTags, IrcWhisperCommandParameters>
{
    public WhisperIrcMessage(WhisperTags? tags, IrcSource prefix, IrcWhisperCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}