using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;
using BindyTwitchLib.Irc.Models.Tags;

namespace BindyTwitchLib.Irc.Models.Messages;

public class PrivMsgIrcMessage : IrcMessageWithTagsAndCommandParameters<PrivMsgTags, IrcPrivMsgCommandParameters, PrivMsgIrcMessage>
{
    public PrivMsgIrcMessage(PrivMsgTags? tags, IrcSource prefix, IrcPrivMsgCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}