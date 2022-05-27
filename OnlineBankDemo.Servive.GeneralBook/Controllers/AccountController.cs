using OnlineBankDemo.DataAccessLayer.GeneralBook;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace OnlineBankDemo.Servive.GeneralBook.Controllers
{
    public class AccountController : Controller
    {
        protected GeneralBookEntityContext _context;

        public AccountController()
        {
        }

        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            var connString = ConfigurationManager.AppSettings["DbConnectionString"];
            using (var context = new GeneralBookEntityContext(connString))
            {
                var accounts = context.Accounts.ToList();
                return Json(accounts, JsonRequestBehavior.AllowGet);
            }            
        }
    }
}