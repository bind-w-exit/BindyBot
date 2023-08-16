namespace BindyTwitchLib.Irc.Helpers;

public static class ReadOnlySpanExtensions
{
    public static bool StartsWithChar(this ReadOnlySpan<char> span, char value)
    {
        return span.Length > 0 && span[0] == value;
    }
}