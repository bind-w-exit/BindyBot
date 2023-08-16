using BindyTwitchLib.Irc.Models.Tags.Contracts;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BindyTwitchLib.Irc.Models.Tags;

public partial record BadgeInfo(uint Subscriber) : IIrcTag<BadgeInfo>
{
    [GeneratedRegex(@"(?<key>[^/]+)/(?<value>[^/]+)")]
    private static partial Regex BadgeInfoRegex();  // Currently, this tag contains metadata only for subscriber badges

    public static BadgeInfo Parse(string s, IFormatProvider? provider = null)
    {
        if (!TryParse(s, provider, out var result))
        {
            throw new ArgumentException("Expect: subscriber/[number_of_months]");   // subscriber/8
        }

        return result;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out BadgeInfo result)
    {
        if (!string.IsNullOrWhiteSpace(s))
        {
            var match = BadgeInfoRegex().Match(s);

            if (match.Success)
            {
                var key = match.Groups["key"].Value;
                var value = match.Groups["value"].Value;

                if (key == "subscriber" && uint.TryParse(value, NumberStyles.None, provider, out var to))
                {
                    result = new BadgeInfo(to);
                    return true;
                }
            }
        }

        result = default;
        return false;
    }

    // TODO: Test performance?
    //public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out BadgeInfo result)
    //{
    //    if (!string.IsNullOrWhiteSpace(s))
    //    {
    //        var keyValuePairs = s.Split(',');

    //        foreach (var keyValuePair in keyValuePairs)
    //        {
    //            var pairComponents = keyValuePair.Split('/');

    //            if (pairComponents.Length == 2)
    //            {
    //                var key = pairComponents[0];
    //                var value = pairComponents[1];

    //                switch (key)
    //                {
    //                    case "subscriber" when uint.TryParse(value, NumberStyles.None, provider, out var to):
    //                        result = new BadgeInfo(to);
    //                        return true;
    //                }
    //            }
    //        }
    //    }

    //    result = default;
    //    return false;
    //}
}