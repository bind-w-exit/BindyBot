using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcCreatedCommandParameters
{
    public string CreatedMessage { get; set; }
}

public partial class IrcCreatedCommandParameters : IrcCommandParameters<IrcCreatedCommandParameters>
{
    protected override IrcCreatedCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}