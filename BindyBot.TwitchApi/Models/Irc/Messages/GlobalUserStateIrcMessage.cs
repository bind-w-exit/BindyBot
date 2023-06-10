using BindyBot.TwitchApi.Models.Irc.Contracts;
using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class GlobalUserStateIrcMessage : IrcMessageWithTags<GlobalUserStateTags>
{
    public GlobalUserStateIrcMessage(GlobalUserStateTags? tags, IrcSource prefix) : base(tags, prefix)
    {
    }
}