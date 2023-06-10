using BindyBot.TwitchApi.Models.Irc.Contracts;
using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class PrivMsgIrcMessage : IrcMessageWithTagsAndCommandParameters<PrivMsgTags, IrcPrivMsgCommandParameters>
{
    public PrivMsgIrcMessage(PrivMsgTags? tags, IrcSource prefix, IrcPrivMsgCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}