namespace OnlineBankDemo.Security.Common
{
    public interface ISecurityProvider
    {
        bool ThrowOnDeny { get; set; }
    }
}