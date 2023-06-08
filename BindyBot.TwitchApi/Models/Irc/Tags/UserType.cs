using System.ComponentModel;

namespace BindyBot.TwitchApi.Models.Irc.Tags;

public enum UserType
{
    [Description("")]
    None,

    [Description("admin")]
    Admin,

    [Description("global_mod")]
    GlobalMod,

    [Description("staff")]
    Staff
}