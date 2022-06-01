using System;

namespace OnlineBankDemo.Security.Common
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SecureMethodAttribute : BaseSecurityAttribute
    {
        public SecureMethodAttribute(string description) : base(description)
        {
        }
    }
}