using System;

namespace DotnetSandbox.Common
{
    public static class StringFunctions
    {
        public static string Capitalize(this string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
        }

        public static int GetQuarterNumber(this DateTime dateTime)
        {
            return (dateTime.Month + 2) / 3;
        }
    }
}