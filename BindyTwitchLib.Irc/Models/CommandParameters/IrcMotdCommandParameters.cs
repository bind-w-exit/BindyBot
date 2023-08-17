using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcMotdCommandParameters
{
    public string MessageOfTheDay { get; set; }
}

public partial class IrcMotdCommandParameters : IrcCommandParameters<IrcMotdCommandParameters>
{
    protected override IrcMotdCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}