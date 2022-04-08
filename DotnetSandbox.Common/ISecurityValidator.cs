namespace DotnetSandbox.Common
{
    public interface ISecurityValidator
    {
        bool Validate();
    }
    
    public class SimpleSecurityValidator: ISecurityValidator
    {
        public bool Validate()
        {
            return OnlineBankContext.CurrentUserID == 9999;
        }
    }
}