using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcPingCommandParameters
{
    public string ServerName { get; set; }
}

public partial class IrcPingCommandParameters : IrcCommandParameters<IrcPingCommandParameters>
{
    protected override IrcPingCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}