using BindyTwitchLib.Irc.Models.CommandParameters;
using BindyTwitchLib.Irc.Models.Messages.Contracts;
using BindyTwitchLib.Irc.Models.Tags;

namespace BindyTwitchLib.Irc.Models.Messages;

public class RoomStateIrcMessage : IrcMessageWithTagsAndCommandParameters<RoomStateTags, IrcRoomStateCommandParameters, RoomStateIrcMessage>
{
    public RoomStateIrcMessage(RoomStateTags? tags, IrcSource prefix, IrcRoomStateCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}