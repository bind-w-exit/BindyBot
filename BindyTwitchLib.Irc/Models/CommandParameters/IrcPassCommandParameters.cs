using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcPassCommandParameters
{
    public string AccessToken { get; set; }
}

public partial class IrcPassCommandParameters : IrcCommandParameters<IrcPassCommandParameters>
{
    protected override IrcPassCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}