using System.Diagnostics.CodeAnalysis;

namespace BindyTwitchLib.Irc.Models.Tags.Contracts;

public abstract class IrcTags<TSelf> : IIrcTags<TSelf>
    where TSelf : IrcTags<TSelf>, new()
{
    public static TSelf Parse(string s, IFormatProvider? provider)
    {
        var tags = GetTags(s);
        var tagInstance = new TSelf();
        tagInstance.ParseFromDictionary(tags);
        return tagInstance;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result)
    {
        throw new NotImplementedException();
    }

    protected abstract TSelf ParseFromDictionary(Dictionary<string, string> tags);

    private static Dictionary<string, string> GetTags(string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentNullException(nameof(s));

        if (!s.StartsWith('@'))
            throw new ArgumentException("Invalid tags format.");

        s = s.Trim()[1..];  // Remove '@'
        string[] tagsWithValue = s.Split(';');

        Dictionary<string, string> tags = new();

        foreach (var tagWithValue in tagsWithValue)
        {
            var tagValuePair = tagWithValue.Split('=');
            var key = tagValuePair[0];

            if (tagValuePair.Length == 2)
            {
                var value = tagValuePair[1];
                tags[key] = value;
            }
            else if (tagValuePair.Length == 1)
            {
                // Handle tag without value
                tags[key] = string.Empty;
            }
            else
                throw new ArgumentException($"Invalid tag format. Tag name: {key}");
        }

        return tags;
    }
}