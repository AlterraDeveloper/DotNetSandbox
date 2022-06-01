using System;

namespace OnlineBankDemo.Security.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SecureClassAttribute : BaseSecurityAttribute
    {
        public SecureClassAttribute(string description) : base(description)
        {
        }
    }
}