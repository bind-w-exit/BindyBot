using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcNickCommandParameters
{
    public string Nickname { get; set; }
}

public partial class IrcNickCommandParameters : IrcCommandParameters<IrcNickCommandParameters>
{
    protected override IrcNickCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}