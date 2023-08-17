using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcWelcomeCommandParameters
{
    public string WelcomeMessage { get; set; }
}

public partial class IrcWelcomeCommandParameters : IrcCommandParameters<IrcWelcomeCommandParameters>
{
    protected override IrcWelcomeCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}