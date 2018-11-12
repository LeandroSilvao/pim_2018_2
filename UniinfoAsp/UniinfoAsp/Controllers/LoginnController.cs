using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniinfoAsp.Models;

namespace UniinfoAsp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LoginnController : Controller
    {
        private UnipEntities db = new UnipEntities();

        // GET: Loginn
        public ActionResult Index()
        {
            var loginns = db.Loginns.Include(l => l.Funcionario).Include(l => l.nivelAcesso);
            return View(loginns.ToList());
        }

        // GET: Loginn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loginn loginn = db.Loginns.Find(id);
            if (loginn == null)
            {
                return HttpNotFound();
            }
            return View(loginn);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public ActionResult detailsDeleteConfirmed(int id)
        {
            Loginn loginn = db.Loginns.Find(id);
            db.Loginns.Remove(loginn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Loginn/Create
        public ActionResult Create()
        {
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome");
            ViewBag.idNivelAcesso = new SelectList(db.nivelAcessoes, "idNivelAcesso", "tipoAcesso");
            return View();
        }

        // POST: Loginn/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLogin,idFuncionario,login,senha,idNivelAcesso")] Loginn loginn)
        {
            if (ModelState.IsValid)
            {
                db.Loginns.Add(loginn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", loginn.idFuncionario);
            ViewBag.idNivelAcesso = new SelectList(db.nivelAcessoes, "idNivelAcesso", "tipoAcesso", loginn.idNivelAcesso);
            return View(loginn);
        }

        public JsonResult loginExistente(string login)
        {
            return Json(!db.Loginns.Any(l => l.login == login), JsonRequestBehavior.AllowGet);
        }

        // GET: Loginn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loginn loginn = db.Loginns.Find(id);
            if (loginn == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", loginn.idFuncionario);
            ViewBag.idNivelAcesso = new SelectList(db.nivelAcessoes, "idNivelAcesso", "tipoAcesso", loginn.idNivelAcesso);
            return View(loginn);
        }

        // POST: Loginn/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLogin,idFuncionario,login,senha,idNivelAcesso")] Loginn loginn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", loginn.idFuncionario);
            ViewBag.idNivelAcesso = new SelectList(db.nivelAcessoes, "idNivelAcesso", "tipoAcesso", loginn.idNivelAcesso);
            return View(loginn);
        }

        // GET: Loginn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loginn loginn = db.Loginns.Find(id);
            if (loginn == null)
            {
                return HttpNotFound();
            }
            return View(loginn);
        }

        // POST: Loginn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loginn loginn = db.Loginns.Find(id);
            db.Loginns.Remove(loginn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
