using BindyBot.TwitchApi.Models.Irc.Contracts;
using BindyBot.TwitchApi.Models.Irc.Tags;

namespace BindyBot.TwitchApi.Models.Irc.Messages;

public class RoomStateIrcMessage : IrcMessageWithTagsAndCommandParameters<RoomStateTags, IrcRoomStateCommandParameters>
{
    public RoomStateIrcMessage(RoomStateTags? tags, IrcSource prefix, IrcRoomStateCommandParameters parameters) : base(tags, prefix, parameters)
    {
    }
}