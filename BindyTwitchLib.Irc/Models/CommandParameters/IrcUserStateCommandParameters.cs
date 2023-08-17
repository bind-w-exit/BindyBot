using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcUserStateCommandParameters
{
    public string Channel { get; set; }
}

public partial class IrcUserStateCommandParameters : IrcCommandParameters<IrcUserStateCommandParameters>
{
    protected override IrcUserStateCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}