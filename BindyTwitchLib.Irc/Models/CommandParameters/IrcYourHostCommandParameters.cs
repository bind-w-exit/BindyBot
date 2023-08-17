using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcYourHostCommandParameters
{
    public string YourHostMessage { get; set; }
}

public partial class IrcYourHostCommandParameters : IrcCommandParameters<IrcYourHostCommandParameters>
{
    protected override IrcYourHostCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}