//using System.Diagnostics.CodeAnalysis;
//using System.Text.RegularExpressions;

//namespace BindyTwitchLib.Irc.Models.Tags;

//public partial record Badges(bool? Admin = null, int? Bits = null, bool? Broadcaster = null, bool? Moderator = null, uint? Subscriber = null, bool? Staff = null, bool? Turbo = null) : IIrcTag<Badges>
//{
//    [GeneratedRegex(@"(?<key>[^,]+)\/(?<value>[^,]+)")]
//    private static partial Regex BadgesRegex();  // Currently, this tag contains metadata only for subscriber badges

//    public static Badges Parse(string s, IFormatProvider? provider = null)
//    {
//        if (!TryParse(s, provider, out var result))
//        {
//            throw new ArgumentException();
//        }

//        return result;
//    }

//    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Badges result)
//    {
//        if (!string.IsNullOrWhiteSpace(s))
//        {
//            var matches = BadgesRegex().Matches(s);

//            result = new Badges();

//            foreach (Match match in matches)
//            {
//                var key = match.Groups["key"].Value;
//                var value = match.Groups["value"].Value;

//                switch (key)
//                {
//                    case "admin" when byte.TryParse(value, out byte admin):
//                        result = result with { Admin = Convert.ToBoolean(admin) };
//                        break;

//                    case "bits" when int.TryParse(value, out int bits):
//                        result = result with { Bits = bits };
//                        break;

//                    case "broadcaster" when byte.TryParse(value, out byte broadcaster):
//                        result = result with { Broadcaster = Convert.ToBoolean(broadcaster) };
//                        break;

//                    case "moderator" when byte.TryParse(value, out byte moderator):
//                        result = result with { Moderator = Convert.ToBoolean(moderator) };
//                        break;

//                    case "subscriber" when uint.TryParse(value, out uint subscriber):
//                        result = result with { Subscriber = subscriber };
//                        break;

//                    case "staff" when byte.TryParse(value, out byte staff):
//                        result = result with { Staff = Convert.ToBoolean(staff) };
//                        break;

//                    case "turbo" when byte.TryParse(value, out byte turbo):
//                        result = result with { Turbo = Convert.ToBoolean(turbo) };
//                        break;
//                    // Add more cases for other possible badge keys here

//                    default:
//                        // Handle unrecognized keys or values if needed
//                        break;
//                }
//            }

//            return true;
//        }

//        result = default;
//        return false;
//    }
//}