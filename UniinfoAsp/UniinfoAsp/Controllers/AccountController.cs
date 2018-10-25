using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using UniinfoAsp.Models;

namespace UniinfoAsp.Controllers
{
    public class AccountController : Controller
    {
        UnipEntities db = new UnipEntities();
        
        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(Loginn log)
        {
            var result = db.Loginns.Where(a => a.login == log.login && a.senha == log.senha).ToList();
            if (result.Count() > 0)
            {
                Session["idLogin"] = result[0].idLogin;
                FormsAuthentication.SetAuthCookie(result[0].login, false);
                //If admin
                if (result[0].idNivelAcesso == 1)
                {
                    return RedirectToAction("../Admin/index");
                }
                //If Funcionario
                if (result[0].idNivelAcesso == 2)
                {
                    return RedirectToAction("../Func/index");
                }
            }
            else
            {
                ViewBag.Message = "Erro, Usuario ou senha incorreto";
            }
            return View(log);
        }

        public ActionResult LogOut()
        {
            Session["idLogin"] = 0;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}