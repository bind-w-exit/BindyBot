using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcWhisperCommandParameters
{
    public string FromUser { get; set; }
    public string Message { get; set; }
}

public partial class IrcWhisperCommandParameters : IrcCommandParameters<IrcWhisperCommandParameters>
{
    protected override IrcWhisperCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}