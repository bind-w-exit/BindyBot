using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcUserNoticeCommandParameters
{
    public string Channel { get; set; }
    public string? Message { get; set; }
}

public partial class IrcUserNoticeCommandParameters : IrcCommandParameters<IrcUserNoticeCommandParameters>
{
    protected override IrcUserNoticeCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}