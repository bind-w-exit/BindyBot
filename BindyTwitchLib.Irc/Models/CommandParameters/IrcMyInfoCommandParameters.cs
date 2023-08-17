using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcMyInfoCommandParameters
{
    public string MyInfoMessage { get; set; }
}

public partial class IrcMyInfoCommandParameters : IrcCommandParameters<IrcMyInfoCommandParameters>
{
    protected override IrcMyInfoCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}