using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcClearMsgCommandParameters
{
    public string Channel { get; set; }

    public string Message { get; set; }
}

public partial class IrcClearMsgCommandParameters : IrcCommandParameters<IrcClearMsgCommandParameters>
{
    protected override IrcClearMsgCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}