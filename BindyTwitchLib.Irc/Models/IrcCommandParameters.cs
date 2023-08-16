namespace BindyTwitchLib.Irc.Models;

public interface IIrcCommandParameters { }

#region Supported IRC messages

public record IrcJoinCommandParameters(IEnumerable<string> Channels) : IIrcCommandParameters;

public record IrcNickCommandParameters(string Nickname) : IIrcCommandParameters;

public record IrcNoticeCommandParameters(string Channel, string Message) : IIrcCommandParameters;

public record IrcPartCommandParameters(IEnumerable<string> Channels, string? Reason = null) : IIrcCommandParameters;

public record IrcPassCommandParameters(string AccessToken) : IIrcCommandParameters;

public record IrcPingCommandParameters(string ServerName) : IIrcCommandParameters;

public record IrcPongCommandParameters(string ServerName) : IIrcCommandParameters;

public record IrcPrivMsgCommandParameters(string Channel, string Message) : IIrcCommandParameters;

#endregion Supported IRC messages

#region Twitch-specific IRC messages

public record IrcClearChatCommandParameters(string Channel, string User) : IIrcCommandParameters;

public record IrcClearMsgCommandParameters(string Channel, string Message) : IIrcCommandParameters;

public record IrcHostTargetCommandParameters(string Channel, string TargetChannel, uint Viewers) : IIrcCommandParameters;

public record IrcRoomStateCommandParameters(string Channel) : IIrcCommandParameters;

public record IrcUserNoticeCommandParameters(string Channel, string? Message = null) : IIrcCommandParameters;

public record IrcUserStateCommandParameters(string Channel) : IIrcCommandParameters;

public record IrcWhisperCommandParameters(string FromUser, string Message) : IIrcCommandParameters;

#endregion Twitch-specific IRC messages

#region Supported numeric IRC messages

public record IrcWelcomeCommandParameters(string WelcomeMessage) : IIrcCommandParameters;

public record IrcYourHostCommandParameters(string YourHostMessage) : IIrcCommandParameters;

public record IrcCreatedCommandParameters(string CreatedMessage) : IIrcCommandParameters;

public record IrcMyInfoCommandParameters(string MyInfoMessage) : IIrcCommandParameters;

public record IrcNamReplyCommandParameters(string Channel, IEnumerable<string> Users) : IIrcCommandParameters;

public record IrcEndOfNamesCommandParameters(string Channel, string EndOfNamesMessage) : IIrcCommandParameters;

public record IrcMotdCommandParameters(string MessageOfTheDay) : IIrcCommandParameters;

public record IrcMotdStartCommandParameters(string MessageOfTheDayStart) : IIrcCommandParameters;

public record IrcEndOfMotdCommandParameters(string EndOfMessageOfTheDay) : IIrcCommandParameters;

public record IrcUnknownCommandCommandParameters(string? User, string Command, string UnknownCommandMessage) : IIrcCommandParameters;

#endregion Supported numeric IRC messages