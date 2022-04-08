using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotnetSandbox.Common
{
    public static class RegexSandbox
    {
        public static bool ValidateInn(string inn)
        {
            return Regex.IsMatch(inn, @"^[012]\d{13}$");
        }


        public static Match SearchMe(string mySurname)
        {
            return Regex.Match(mySurname, @"[Kk]is\w{1}lev");
        }

        public static string ReplacementSymbols(string template)
        {
            var customerID = 496486;
            var accountNo = "4484978974869498";
            var symbols = new List<string>
            {
                "[AccountNo]",
                "[CustomerID]"
            };
            
            template = Regex.Replace(template, @"\[AccountNo\]", accountNo);
            template = Regex.Replace(template, @"\[CustomerID\]", customerID.ToString());

            return template;
        }
    }
}