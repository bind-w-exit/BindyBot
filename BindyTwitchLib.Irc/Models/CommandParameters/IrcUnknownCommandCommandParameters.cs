using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcUnknownCommandCommandParameters
{
    public string? User { get; set; }
    public string Command { get; set; }
    public string UnknownCommandMessage { get; set; }
}

public partial class IrcUnknownCommandCommandParameters : IrcCommandParameters<IrcUnknownCommandCommandParameters>
{
    protected override IrcUnknownCommandCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}