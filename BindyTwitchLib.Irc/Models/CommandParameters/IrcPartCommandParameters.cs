using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcPartCommandParameters
{
    public IEnumerable<string> Channels { get; set; }
    public string? Reason { get; set; }
}

public partial class IrcPartCommandParameters : IrcCommandParameters<IrcPartCommandParameters>
{
    protected override IrcPartCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}