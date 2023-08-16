namespace BindyTwitchLib.Irc.Helpers;

internal static class ParseExtensions
{
    public static bool ToBoolFromNum(this string? number)
    {
        if (number == "1")
        {
            return true;
        }
        else if (number == "0")
        {
            return false;
        }
        else
        {
            throw new ArgumentException("Invalid input for parsing into bool.");
        }
    }
}