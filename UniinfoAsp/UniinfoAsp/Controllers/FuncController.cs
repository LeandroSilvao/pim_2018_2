using System.Web.Mvc;
using UniinfoAsp.Models;

namespace UniinfoAsp.Controllers
{
    public class FuncController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}