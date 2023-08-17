using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcPongCommandParameters
{
    public string ServerName { get; set; }
}

public partial class IrcPongCommandParameters : IrcCommandParameters<IrcPongCommandParameters>
{
    protected override IrcPongCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}