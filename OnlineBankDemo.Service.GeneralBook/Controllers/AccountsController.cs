using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using OnlineBankDemo.DataAccessLayer.GeneralBook;
using OnlineBankDemo.DomainModel.Common;
using OnlineBankDemo.Security.Common;
using OnlineBankDemo.Security.GeneralBook;

namespace OnlineBankDemo.Service.GeneralBook.Controllers
{
    public class AccountsController : ApiController
    {
        protected readonly GeneralBookUnitOfWork _uow;
        private readonly AccountsControllerSecurityProvider _securityProvider;
        private readonly ISecurityProviderValidator _validator;
        
        public AccountsController(GeneralBookUnitOfWork uow, ISecurityProviderValidator validator)
        {
            _uow = uow;
            _securityProvider = new AccountsControllerSecurityProvider(validator);
        }
        
        // GET
        [HttpGet]
        public JsonResult<List<Account>> Index()
        {
            var accounts = new List<Account>();
            if (_securityProvider.IsAccountsGetAllowed())
            {
                accounts = _uow.GetCommonRepository<Account>().GetAll().ToList();
            }
            return Json(accounts);
        }
    }
}

