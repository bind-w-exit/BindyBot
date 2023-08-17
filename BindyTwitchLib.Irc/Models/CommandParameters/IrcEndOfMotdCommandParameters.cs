using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcEndOfMotdCommandParameters
{
    public string EndOfMessageOfTheDay { get; set; }
}

public partial class IrcEndOfMotdCommandParameters : IrcCommandParameters<IrcEndOfMotdCommandParameters>
{
    protected override IrcEndOfMotdCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}