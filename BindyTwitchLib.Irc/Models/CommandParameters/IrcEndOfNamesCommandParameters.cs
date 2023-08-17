using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcEndOfNamesCommandParameters
{
    public string Channel { get; set; }
    public string EndOfNamesMessage { get; set; }
}

public partial class IrcEndOfNamesCommandParameters : IrcCommandParameters<IrcEndOfNamesCommandParameters>
{
    protected override IrcEndOfNamesCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}