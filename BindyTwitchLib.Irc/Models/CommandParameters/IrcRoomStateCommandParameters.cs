using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcRoomStateCommandParameters
{
    public string Channel { get; set; }
}

public partial class IrcRoomStateCommandParameters : IrcCommandParameters<IrcRoomStateCommandParameters>
{
    protected override IrcRoomStateCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}