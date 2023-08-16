using BindyTwitchLib.Irc.Helpers;
using BindyTwitchLib.Irc.Models.Tags.Contracts;
using System.ComponentModel;

namespace BindyTwitchLib.Irc.Models.Tags;

// https://dev.twitch.tv/docs/irc/tags/#notice-tags
// Prototype: @msg-id=<msg-id>;target-user-id=<user-id>
public class NoticeTags : IrcTags<NoticeTags>
{
    /// <summary>
    /// An ID that you can use to programmatically determine the action’s outcome. For a list of possible IDs, see NOTICE Message IDs.
    /// </summary>
    [IrcTag("msg-id")]
    public NoticeMsgId MsgId { get; set; }

    /// <summary>
    /// The ID of the user that the action targeted.
    /// </summary>
    [IrcTag("target-user-id")]
    public long TargetUserId { get; set; }

    protected override NoticeTags ParseFromDictionary(Dictionary<string, string> tags)
    {
        throw new NotImplementedException();
    }
}

// https://dev.twitch.tv/docs/irc/msg-id/
public enum NoticeMsgId
{
    // TODO: Not full enum

    [Description("bad_ban_self")]
    BadBanSelf,

    [Description("bad_ban_staff")]
    BadBanStaff,

    [Description("bad_commercial_error")]
    BadCommercialError,

    [Description("bad_delete_message_broadcaster")]
    BadDeleteMessageBroadcaster,

    [Description("bad_delete_message_mod")]
    BadDeleteMessageMod,

    [Description("bad_host_error")]
    BadHostError,

    [Description("bad_host_hosting")]
    BadHostHosting,

    [Description("bad_host_rate_exceeded")]
    BadHostRateExceeded,

    [Description("bad_host_rejected")]
    BadHostRejected,

    [Description("bad_host_self")]
    BadHostSelf,

    [Description("bad_mod_banned")]
    BadModBanned,

    [Description("bad_mod_mod")]
    BadModMod,

    [Description("bad_slow_duration")]
    BadSlowDuration,

    [Description("bad_timeout_admin")]
    BadTimeoutAdmin,

    [Description("bad_timeout_anon")]
    BadTimeoutAnon,

    [Description("bad_timeout_broadcaster")]
    BadTimeoutBroadcaster,

    [Description("bad_timeout_duration")]
    BadTimeoutDuration,

    [Description("bad_timeout_mod")]
    BadTimeoutMod,

    [Description("bad_timeout_self")]
    BadTimeoutSelf,

    [Description("bad_timeout_staff")]
    BadTimeoutStaff,

    [Description("bad_unban_no_ban")]
    BadUnbanNoBan,

    [Description("bad_unhost_error")]
    BadUnhostError,

    [Description("bad_unmod_mod")]
    BadUnmodMod,

    [Description("bad_vip_grantee_banned")]
    BadVipGranteeBanned,

    [Description("bad_vip_grantee_already_vip")]
    BadVipGranteeAlreadyVip,

    [Description("bad_vip_max_vips_reached")]
    BadVipMaxVipsReached,

    [Description("bad_vip_achievement_incomplete")]
    BadVipAchievementIncomplete,

    [Description("bad_unvip_grantee_not_vip")]
    BadUnvipGranteeNotVip,

    [Description("ban_success")]
    BanSuccess,

    [Description("cmds_available")]
    CmdsAvailable,

    [Description("color_changed")]
    ColorChanged,

    [Description("commercial_success")]
    CommercialSuccess,

    [Description("delete_message_success")]
    DeleteMessageSuccess,

    [Description("delete_staff_message_success")]
    DeleteStaffMessageSuccess,

    [Description("emote_only_off")]
    EmoteOnlyOff,

    [Description("emote_only_on")]
    EmoteOnlyOn,

    [Description("followers_off")]
    FollowersOff,

    [Description("followers_on")]
    FollowersOn,

    [Description("followers_on_zero")]
    FollowersOnZero,

    [Description("host_off")]
    HostOff,

    [Description("host_on")]
    HostOn,

    [Description("host_receive")]
    HostReceive,

    [Description("host_receive_no_count")]
    HostReceiveNoCount,

    [Description("host_target_went_offline")]
    HostTargetWentOffline,

    [Description("hosts_remaining")]
    HostsRemaining,

    [Description("invalid_user")]
    InvalidUser,

    [Description("mod_success")]
    ModSuccess,

    [Description("msg_banned")]
    MsgBanned,

    [Description("msg_bad_characters")]
    MsgBadCharacters,

    [Description("msg_channel_blocked")]
    MsgChannelBlocked,

    [Description("msg_channel_suspended")]
    MsgChannelSuspended,

    [Description("msg_duplicate")]
    MsgDuplicate,

    [Description("msg_emoteonly")]
    MsgEmoteonly,

    [Description("msg_followersonly")]
    MsgFollowersonly,

    [Description("msg_followers")]
    MsgFollowers,

    [Description("msg_followersonly_followed")]
    MsgFollowersonlyFollowed,

    [Description("msg_followersonly_zero")]
    MsgFollowersonlyZero,

    [Description("msg_ratelimit")]
    MsgRatelimit,

    [Description("msg_rejected")]
    MsgRejected,

    [Description("msg_rejected_mandatory")]
    MsgRejectedMandatory,

    [Description("msg_requires_verified_phone_number")]
    MsgRequiresVerifiedPhoneNumber,

    [Description("msg_slowmode")]
    MsgSlowmode,

    [Description("msg_subsonly")]
    MsgSubsonly,

    [Description("subscriber_only_mode_chat")]
    SubscriberOnlyModeChat,

    [Description("msg_suspended")]
    MsgSuspended,

    [Description("msg_timedout")]
    MsgTimedout,

    [Description("msg_verified_email")]
    MsgVerifiedEmail,

    [Description("no_help")]
    NoHelp,

    [Description("no_mods")]
    NoMods,

    [Description("no_vips")]
    NoVips,

    [Description("not_hosting")]
    NotHosting,

    [Description("no_permission")]
    NoPermission,

    [Description("raid_error_already_raiding")]
    RaidErrorAlreadyRaiding,

    [Description("raid_error_forbidden")]
    RaidErrorForbidden,

    [Description("raid_error_self")]
    RaidErrorSelf,

    [Description("raid_error_too_many_viewers")]
    RaidErrorTooManyViewers,

    [Description("raid_error_unexpected")]
    RaidErrorUnexpected,

    [Description("raid_notice_mature")]
    RaidNoticeMature,

    [Description("raid_notice_restricted_chat")]
    RaidNoticeRestrictedChat,

    [Description("room_mods")]
    RoomMods,

    [Description("slow_off")]
    SlowOff,

    [Description("slow_on")]
    SlowOn,

    [Description("subs_off")]
    SubsOff,

    [Description("subs_on")]
    SubsOn,

    [Description("timeout_no_timeout")]
    TimeoutNoTimeout,

    [Description("timeout_success")]
    TimeoutSuccess,

    [Description("tos_ban")]
    TosBan,

    [Description("turbo_only_color")]
    TurboOnlyColor,

    [Description("unavailable_command")]
    UnavailableCommand,

    [Description("unban_success")]
    UnbanSuccess,

    [Description("unmod_success")]
    UnmodSuccess,

    [Description("unraid_error_no_active_raid")]
    UnraidErrorNoActiveRaid,

    [Description("unraid_error_unexpected")]
    UnraidErrorUnexpected,

    [Description("unraid_success")]
    UnraidSuccess,

    [Description("unrecognized_cmd")]
    UnrecognizedCmd,

    [Description("untimeout_banned")]
    UntimeoutBanned,

    [Description("untimeout_success")]
    UntimeoutSuccess,

    [Description("unvip_success")]
    UnvipSuccess,

    [Description("usage_ban")]
    UsageBan,

    [Description("usage_clear")]
    UsageClear,

    [Description("usage_color")]
    UsageColor,

    [Description("usage_commercial")]
    UsageCommercial,

    [Description("usage_disconnect")]
    UsageDisconnect,

    [Description("usage_delete")]
    UsageDelete,

    [Description("usage_emote_only_off")]
    UsageEmoteOnlyOff,

    [Description("usage_emote_only_on")]
    UsageEmoteOnlyOn,

    [Description("usage_followers_off")]
    UsageFollowersOff,

    [Description("usage_followers_on")]
    UsageFollowersOn,

    [Description("usage_help")]
    UsageHelp,

    [Description("usage_host")]
    UsageHost,

    [Description("usage_marker")]
    UsageMarker,

    [Description("usage_me")]
    UsageMe,

    [Description("usage_mod")]
    UsageMod,

    [Description("usage_mods")]
    UsageMods,

    [Description("usage_raid")]
    UsageRaid,

    [Description("usage_slow_off")]
    UsageSlowOff,

    [Description("usage_slow_on")]
    UsageSlowOn,

    [Description("usage_subs_off")]
    UsageSubsOff,

    [Description("usage_subs_on")]
    UsageSubsOn,

    [Description("usage_timeout")]
    UsageTimeout,

    [Description("usage_unban")]
    UsageUnban,

    [Description("usage_unhost")]
    UsageUnhost,

    [Description("usage_unmod")]
    UsageUnmod,

    [Description("usage_unraid")]
    UsageUnraid,

    [Description("usage_untimeout")]
    UsageUntimeout,

    [Description("usage_unvip")]
    UsageUnvip,

    [Description("usage_user")]
    UsageUser,

    [Description("usage_vip")]
    UsageVip,

    [Description("usage_vips")]
    UsageVips,

    [Description("usage_whisper")]
    UsageWhisper,

    [Description("vip_success")]
    VipSuccess,

    [Description("vips_success")]
    VipsSuccess,

    [Description("whisper_banned")]
    WhisperBanned,

    [Description("whisper_banned_recipient")]
    WhisperBannedRecipient,

    [Description("whisper_invalid_login")]
    WhisperInvalidLogin,

    [Description("whisper_invalid_self")]
    WhisperInvalidSelf,

    [Description("whisper_limit_per_min")]
    WhisperLimitPerMin,

    [Description("whisper_limit_per_sec")]
    WhisperLimitPerSec,

    [Description("whisper_restricted")]
    WhisperRestricted,

    [Description("whisper_restricted_recipient")]
    WhisperRestrictedRecipient
}