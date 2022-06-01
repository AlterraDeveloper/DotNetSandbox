namespace OnlineBankDemo.Security.Common
{
    public interface ISecurityProviderValidator 
    {
        bool Approved(object obj, bool throwOnDeny);
    }
}