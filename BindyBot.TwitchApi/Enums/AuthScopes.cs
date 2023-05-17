using System.ComponentModel;

namespace BindyBot.TwitchApi.Enums;

public enum AuthScopes
{
    [Description("channel:read")]
    ChannelRead,

    [Description("channel:edit")]
    ChannelEdit,

    [Description("channel:moderate")]
    ChannelModerate,

    [Description("channel:subscriptions")]
    ChannelSubscriptions,

    [Description("bits:read")]
    BitsRead,

    [Description("bits:write")]
    BitsWrite,

    [Description("clips:edit")]
    ClipsEdit,

    [Description("user:read:email")]
    UserReadEmail,

    [Description("user:edit")]
    UserEdit,

    [Description("user:edit:broadcast")]
    UserEditBroadcast,

    [Description("user:blocks:edit")]
    UserBlocksEdit,

    [Description("user:blocks:read")]
    UserBlocksRead,

    [Description("user:followers:read")]
    UserFollowersRead,

    [Description("user:read:broadcast")]
    UserReadBroadcast,

    [Description("user:read:subscriptions")]
    UserReadSubscriptions,

    [Description("user:subscriptions")]
    UserSubscriptions,

    [Description("chat:read")]
    ChatRead,

    [Description("chat:edit")]
    ChatEdit,

    [Description("whispers:read")]
    WhispersRead,

    [Description("whispers:edit")]
    WhispersEdit
}

public static class AuthScopesConverter
{
    private static readonly Dictionary<AuthScopes, string> _scopeToDescriptionMap = new();

    static AuthScopesConverter()
    {
        foreach (AuthScopes value in Enum.GetValues(typeof(AuthScopes)))
        {
            var description = GetDescription(value);
            if (description != null)
            {
                _scopeToDescriptionMap[value] = description;
            }
        }
    }
    /// <summary>
    /// Converts the specified <see cref="AuthScopes"/> value to its corresponding <see cref="string"/>  representation.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public static string? ToString(AuthScopes scope)
    {
        if (_scopeToDescriptionMap.TryGetValue(scope, out string? description))
        {
            return description;
        }
        throw new ArgumentException("Unknown AuthScopes value");
    }

    /// <summary>
    /// Converts the specified <see cref="string"/> value to its corresponding <see cref="AuthScopes"/> enum value.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public static AuthScopes FromString(string scope)
    {
        foreach (var pair in _scopeToDescriptionMap)
        {
            if (pair.Value.Equals(scope, StringComparison.OrdinalIgnoreCase))
            {
                return pair.Key;
            }
        }
        throw new ArgumentException("Unknown scope value");
    }

    private static string? GetDescription(AuthScopes scope)
    {
        var fieldInfo = typeof(AuthScopes).GetField(scope.ToString())!;
        var descriptionAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

        return descriptionAttribute?.Description;
    }
}