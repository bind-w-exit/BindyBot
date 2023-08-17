using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;
using BindyTwitchLib.Irc.Models.Tags;

namespace BindyTwitchLib.Irc.Models.Messages;

public class ClearChatIrcMessage : IrcMessageWithTagsAndCommandParameters<ClearChatTags, IrcClearChatCommandParameters, ClearChatIrcMessage>
{
    public ClearChatIrcMessage(ClearChatTags? tags, IrcSource prefix, IrcClearChatCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}