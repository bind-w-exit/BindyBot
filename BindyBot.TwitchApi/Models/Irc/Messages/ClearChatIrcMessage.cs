using BindyBot.TwitchApi.Models.Irc.Contracts;
using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class ClearChatIrcMessage : IrcMessageWithTagsAndCommandParameters<ClearChatTags, IrcClearChatCommandParameters>
{
    public ClearChatIrcMessage(ClearChatTags? tags, IrcSource prefix, IrcClearChatCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}