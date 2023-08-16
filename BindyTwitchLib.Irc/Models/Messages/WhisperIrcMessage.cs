using BindyTwitchLib.Irc.Models.Messages.Contracts;
using BindyTwitchLib.Irc.Models.Tags;

namespace BindyTwitchLib.Irc.Models.Messages;

public class WhisperIrcMessage : IrcMessageWithTagsAndCommandParameters<WhisperTags, IrcWhisperCommandParameters>
{
    public WhisperIrcMessage(WhisperTags? tags, IrcSource prefix, IrcWhisperCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}