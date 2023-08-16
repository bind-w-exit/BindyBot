namespace BindyTwitchLib.Irc.Helpers;

[AttributeUsage(AttributeTargets.Property)]
public class IrcTag : Attribute
{
    public string Name { get; set; }

    public IrcTag(string name)
    {
        Name = name;
    }
}