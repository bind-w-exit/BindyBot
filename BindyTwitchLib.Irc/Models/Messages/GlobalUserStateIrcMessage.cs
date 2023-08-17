using BindyTwitchLib.Irc.Models.Messages.Contracts;
using BindyTwitchLib.Irc.Models.Tags;

namespace BindyTwitchLib.Irc.Models.Messages;

public class GlobalUserStateIrcMessage : IrcMessageWithTags<GlobalUserStateTags, GlobalUserStateIrcMessage>
{
    public GlobalUserStateIrcMessage(GlobalUserStateTags? tags, IrcSource prefix) : base(tags, prefix)
    {
    }
}