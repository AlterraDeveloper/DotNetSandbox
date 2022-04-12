namespace DotnetSandbox.Common
{
    public class BaseSecurityProvider : ISecurityProvider
    {
        public BaseSecurityProvider(ISecurityValidator validator)
        {
            Validator = validator;
        }

        protected readonly ISecurityValidator Validator;
        
        public void Approve(ISecurityValidator validator)
        {
        }
    }

    public class CollectionSecurityProvider : BaseSecurityProvider, ICollectionSecurityProvider
    {
        public virtual bool IsAddAllowed()
        {
            return false;
        }

        public virtual bool IsRemoveAllowed()
        {
            return false;
        }

        public virtual bool IsEditAllowed()
        {
            return false;
        }

        public virtual bool IsViewAllowed()
        {
            return false;
        }

        public CollectionSecurityProvider(ISecurityValidator validator) : base(validator)
        {
        }
    }
    
    public class CustomerCollectionSecurityProvider : CollectionSecurityProvider
    {
        public CustomerCollectionSecurityProvider(ISecurityValidator validator) : base(validator)
        {
        }

        public override bool IsAddAllowed()
        {
            return Validator.Validate();
        }

        public override bool IsViewAllowed()
        {
            return Validator.Validate();
        }

    }
}