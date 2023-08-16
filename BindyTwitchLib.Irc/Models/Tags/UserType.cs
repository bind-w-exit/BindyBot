using System.ComponentModel;

namespace BindyTwitchLib.Irc.Models.Tags;

public enum UserType
{
    [Description("")]
    None,

    [Description("admin")]
    Admin,

    [Description("global_mod")]
    GlobalMod,

    [Description("staff")]
    Staff
}

public static class UserTypeConverter
{
    private static readonly Dictionary<UserType, string> _userTypeToDescriptionMap = new();

    static UserTypeConverter()
    {
        foreach (UserType value in Enum.GetValues(typeof(UserType)))
        {
            var description = GetDescription(value);
            if (description != null)
            {
                _userTypeToDescriptionMap[value] = description;
            }
        }
    }

    /// <summary>
    /// Converts the specified <see cref="UserType"/> value to its corresponding <see cref="string"/>  representation.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public static string? ToString(UserType userType)
    {
        if (_userTypeToDescriptionMap.TryGetValue(userType, out string? description))
        {
            return description;
        }
        throw new ArgumentException("Unknown user type value");
    }

    /// <summary>
    /// Converts the specified <see cref="string"/> value to its corresponding <see cref="UserType"/> enum value.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public static UserType FromString(string userType)
    {
        foreach (var pair in _userTypeToDescriptionMap)
        {
            if (pair.Value.Equals(userType, StringComparison.OrdinalIgnoreCase))
            {
                return pair.Key;
            }
        }
        throw new ArgumentException("Unknown user type value");
    }

    private static string? GetDescription(UserType userType)
    {
        var fieldInfo = typeof(UserType).GetField(userType.ToString())!;
        var descriptionAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

        return descriptionAttribute?.Description;
    }
}