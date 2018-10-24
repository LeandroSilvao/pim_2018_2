using System.Web.Mvc;
using UniinfoAsp.Models;

namespace UniinfoAsp.Controllers
{
    public class AccountController : Controller
    {
        UnipEntities db = new UnipEntities();
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Loginn log)
        {
            return View();
        }
    }
}