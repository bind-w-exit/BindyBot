using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcJoinCommandParameters
{
    public IEnumerable<string> Channels { get; set; }
}

public partial class IrcJoinCommandParameters : IrcCommandParameters<IrcJoinCommandParameters>
{
    protected override IrcJoinCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}