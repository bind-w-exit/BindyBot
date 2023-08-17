using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcHostTargetCommandParameters
{
    public string Channel { get; set; }
    public string TargetChannel { get; set; }
    public uint Viewers { get; set; }
}

public partial class IrcHostTargetCommandParameters : IrcCommandParameters<IrcHostTargetCommandParameters>
{
    protected override IrcHostTargetCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}