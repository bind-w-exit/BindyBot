using BindyTwitchLib.Irc.Helpers;
using BindyTwitchLib.Irc.Models.Tags.Contracts;

namespace BindyTwitchLib.Irc.Models.Tags;

// https://dev.twitch.tv/docs/irc/tags/#clearmsg-tags
// Prototype: @login=<login>;room-id=<room-id>;target-msg-id=<target-msg-id>;tmi-sent-ts=<timestamp>
public class ClearMsgTags : IrcTags<ClearMsgTags>
{
    /// <summary>
    /// The name of the user who sent the message.
    /// </summary>
    [IrcTag("login")]
    public string Login { get; set; }

    /// <summary>
    /// Optional. The ID of the channel (chat room) where the message was removed from.
    /// </summary>
    [IrcTag("room-id")]
    public long? RoomId { get; set; }

    /// <summary>
    /// A UUID that identifies the message that was removed.
    /// </summary>
    [IrcTag("target-msg-id")]
    public long TargetMsgId { get; set; }

    /// <summary>
    /// The UNIX timestamp.
    /// </summary>
    [IrcTag("tmi-sent-ts")]
    public long TmiSentTs { get; set; }

    protected override ClearMsgTags ParseFromDictionary(Dictionary<string, string> tags)
    {
        ClearMsgTags clearMsgTags = new();

        foreach (var (tagName, tagValue) in tags)
        {
            switch (tagName)
            {
                case "login":
                    clearMsgTags.Login = tagValue;
                    break;

                case "room-id" when long.TryParse(tagValue, out var roomId):
                    clearMsgTags.RoomId = roomId;
                    break;

                case "target-user-id" when long.TryParse(tagValue, out var targetUserId):
                    clearMsgTags.TargetMsgId = targetUserId;
                    break;

                case "tmi-sent-ts" when long.TryParse(tagValue, out var tmiSentTs):
                    clearMsgTags.TmiSentTs = tmiSentTs;
                    break;
            }
        }

        return clearMsgTags;
    }
}