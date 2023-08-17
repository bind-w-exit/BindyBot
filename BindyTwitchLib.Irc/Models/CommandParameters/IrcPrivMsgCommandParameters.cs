using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcPrivMsgCommandParameters
{
    public string Channel { get; set; }
    public string Message { get; set; }
}

public partial class IrcPrivMsgCommandParameters : IrcCommandParameters<IrcPrivMsgCommandParameters>
{
    protected override IrcPrivMsgCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}