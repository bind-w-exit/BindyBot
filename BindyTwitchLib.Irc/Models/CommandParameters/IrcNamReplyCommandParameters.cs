using BindyTwitchLib.Irc.Models.CommandParameters.Contracts;

namespace BindyTwitchLib.Irc.Models.CommandParameters;

public partial class IrcNamReplyCommandParameters
{
    public string Channel { get; set; }
    public IEnumerable<string> Users { get; set; }
}

public partial class IrcNamReplyCommandParameters : IrcCommandParameters<IrcNamReplyCommandParameters>
{
    protected override IrcNamReplyCommandParameters ParseFromArray(string[] parameters)
    {
        throw new NotImplementedException();
    }
}