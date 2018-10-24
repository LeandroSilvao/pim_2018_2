using System.Web.Mvc;
using UniinfoAsp.Models;

namespace UniinfoAsp.Controllers
{
    public class FuncController : Controller
    {
        [Authorize(Roles = "Funcionario")]
        public ActionResult Index()
        {
            return View();
        }
    }
}