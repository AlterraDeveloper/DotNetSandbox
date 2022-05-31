using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using OnlineBankDemo.DataAccessLayer.Common;
using OnlineBankDemo.DataAccessLayer.GeneralBook;
using OnlineBankDemo.DomainModel.Common;

namespace OnlineBankDemo.Service.GeneralBook.Controllers
{
    public class AccountsController : ApiController
    {
        protected readonly GeneralBookUnitOfWork _uow;
        
        public AccountsController(GeneralBookUnitOfWork uow)
        {
            _uow = uow;
        }
        
        // GET
        [HttpGet]
        public JsonResult<List<Account>> Index()
        {
            var accounts = _uow.GetCommonRepository<Account>().GetAll().ToList();
            return Json(accounts);
        }
    }
}