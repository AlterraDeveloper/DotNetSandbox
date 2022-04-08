namespace DotnetSandbox.Common
{
    public interface ISecurityProvider
    {
        void Approve(ISecurityValidator validator);
    }

    public interface ICollectionSecurityProvider
    {
        bool IsAddAllowed();

        bool IsRemoveAllowed();

        bool IsEditAllowed();

        bool IsViewAllowed();
    }
}