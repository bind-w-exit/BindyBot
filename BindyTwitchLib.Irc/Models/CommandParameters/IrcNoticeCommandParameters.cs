using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcNoticeCommandParameters
{
    public string Channel { get; set; }
    public string Message { get; set; }
}

public partial class IrcNoticeCommandParameters : IrcCommandParameters<IrcNoticeCommandParameters>
{
    protected override IrcNoticeCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}