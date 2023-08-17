using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcMotdStartCommandParameters
{
    public string MessageOfTheDayStart { get; set; }
}

public partial class IrcMotdStartCommandParameters : IrcCommandParameters<IrcMotdStartCommandParameters>
{
    protected override IrcMotdStartCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}