using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniinfoAsp.Models;

namespace UniinfoAsp.Controllers
{
    [Authorize(Roles = "Funcionario")]
    public class FuncController : Controller
    {
        UnipEntities Db = new UnipEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarChamado()
        {
            ViewBag.funcionarioId = Db.Funcionarios.ToList();
            ViewBag.problema = Db.Problemas.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarChamado(Chamado Cham)
        {
                Cham.dataChamado = System.DateTime.Now;
                Cham.statusAtendimento = "Aberto";
                Db.Chamadoes.Add(Cham);
                Db.SaveChanges();
                return RedirectToAction("CadastrarChamado");
            
            return View(Cham);
        }
    }
}