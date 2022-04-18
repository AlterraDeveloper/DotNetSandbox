using System;

namespace DotnetSandbox.Common
{
    public class OnlineBankException : ApplicationException
    {
        public OnlineBankException(string message, string uniqCode) : base($"{uniqCode}. {message}")
        {
        }
    }
}