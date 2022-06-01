namespace OnlineBankDemo.Security.Common
{
    public class BaseSecurityProvider : ISecurityProvider
    {
        public bool ThrowOnDeny { get; set; } = false;

        protected readonly ISecurityProviderValidator Validator;

        public BaseSecurityProvider(ISecurityProviderValidator validator)
        {
            Validator = validator;
        }
    }
}