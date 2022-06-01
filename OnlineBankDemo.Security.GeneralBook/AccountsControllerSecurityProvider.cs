using OnlineBankDemo.Security.Common;

namespace OnlineBankDemo.Security.GeneralBook
{
    [SecureClass("Контроллер для работы со счетами клиентов")]
    public class AccountsControllerSecurityProvider : BaseSecurityProvider 
    {
        public AccountsControllerSecurityProvider(ISecurityProviderValidator securityProviderValidator) : base(securityProviderValidator)
        {    
        }

        [SecureMethod("Получить счета")]
        public bool IsAccountsGetAllowed() => Validator.Approved(this, ThrowOnDeny);
    }
}