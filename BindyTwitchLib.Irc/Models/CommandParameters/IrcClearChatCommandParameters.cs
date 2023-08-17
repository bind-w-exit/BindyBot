using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcClearChatCommandParameters
{
    public string Channel { get; set; }

    public string User { get; set; }
}

public partial class IrcClearChatCommandParameters : IrcCommandParameters<IrcClearChatCommandParameters>
{
    protected override IrcClearChatCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}