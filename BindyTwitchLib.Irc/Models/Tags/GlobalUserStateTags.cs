using BindyTwitchLib.Irc.Helpers;
using BindyTwitchLib.Irc.Models.Tags.Contracts;
using System.Drawing;

namespace BindyTwitchLib.Irc.Models.Tags;

// https://dev.twitch.tv/docs/irc/tags/#globaluserstate-tags
// Prototype: @badge-info=<badge-info>;badges=<badges>;color=<color>;display-name=<display-name>;emote-sets=<emote-sets>;turbo=<turbo>;user-id=<user-id>;user-type=<user-type>
public partial class GlobalUserStateTags
{
    /// <summary>
    /// Contains metadata related to the chat badges in the badges tag.
    /// Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
    /// </summary>
    [IrcTag("badge-info")]
    public BadgeInfo BadgeInfo { get; set; }

    /// <summary>
    /// Comma-separated list of chat badges in the form, badge/version. For example, admin/1.
    /// </summary>
    [IrcTag("badges")]
    public List<string> Badges { get; set; }

    /// <summary>
    /// The color of the user’s name in the chat room. This is a hexadecimal RGB color code in the form, #RGB. This tag may be empty if it is never set.
    /// </summary>
    [IrcTag("color")]
    public Color? Color { get; set; }

    /// <summary>
    /// The user’s display name, escaped as described in the IRCv3 spec. This tag may be empty if it is never set.
    /// </summary>
    [IrcTag("display-name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// A comma-delimited list of IDs that identify the emote sets that the user has access to.
    /// Is always set to at least zero (0). To access the emotes in the set, use the Get Emote Sets API.
    /// </summary>
    [IrcTag("emote-sets")]
    public List<int> EmoteSets { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether the user has site-wide commercial free mode enabled.
    /// </summary>
    [IrcTag("turbo")]
    public bool Turbo { get; set; }

    [IrcTag("user-id")]
    public uint UserId { get; set; }

    [IrcTag("user-type")]
    public UserType UserType { get; set; }
}

public partial class GlobalUserStateTags : IrcTags<GlobalUserStateTags>
{
    protected override GlobalUserStateTags ParseFromDictionary(Dictionary<string, string> tags)
    {
        GlobalUserStateTags globalUserStateTags = new();

        foreach (var (tagName, tagValue) in tags)
        {
            switch (tagName)
            {
                case "badge-info" when BadgeInfo.TryParse(tagValue, null, out var badgeInfo):
                    globalUserStateTags.BadgeInfo = badgeInfo;
                    break;

                case "badges":
                    globalUserStateTags.Badges = tagValue.Split(',').ToList();
                    break;

                case "color":
                    globalUserStateTags.Color = ColorTranslator.FromHtml(tagValue);
                    break;

                case "display-name":
                    globalUserStateTags.DisplayName = tagValue;
                    break;

                case "emote-sets":
                    string[] numberStrings = tagValue.Split(',');

                    foreach (var numberString in numberStrings)
                        globalUserStateTags.EmoteSets.Add(int.Parse(numberString));

                    break;

                case "turbo":
                    if (tagValue == "0")
                        globalUserStateTags.Turbo = false;
                    else if (tagValue == "1")
                        globalUserStateTags.Turbo = true;
                    break;

                case "user-id" when uint.TryParse(tagValue, out var userId):
                    globalUserStateTags.UserId = userId;
                    break;

                case "user-type":
                    globalUserStateTags.UserType = UserTypeConverter.FromString(tagValue);
                    break;
            }
        }

        return globalUserStateTags;
    }
}