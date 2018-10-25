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
    public class ChamadoController : Controller
    {
        private UnipEntities db = new UnipEntities();

        // GET: Chamado
        public ActionResult Index()
        {
            var chamadoes = db.Chamadoes.Include(c => c.Funcionario).Include(c => c.Problema);
            return View(chamadoes.ToList());
        }

        // GET: Chamado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.Chamadoes.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // GET: Chamado/Create
        public ActionResult Create()
        {
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome");
            ViewBag.idProblema = new SelectList(db.Problemas, "idProblema", "tipoProblema");
            return View();
        }

        // POST: Chamado/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idChamado,idFuncionario,idProblema,descricao,dataChamado,statusAtendimento")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                db.Chamadoes.Add(chamado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", chamado.idFuncionario);
            ViewBag.idProblema = new SelectList(db.Problemas, "idProblema", "tipoProblema", chamado.idProblema);
            return View(chamado);
        }

        // GET: Chamado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.Chamadoes.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", chamado.idFuncionario);
            ViewBag.idProblema = new SelectList(db.Problemas, "idProblema", "tipoProblema", chamado.idProblema);
            return View(chamado);
        }

        // POST: Chamado/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idChamado,idFuncionario,idProblema,descricao,dataChamado,statusAtendimento")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", chamado.idFuncionario);
            ViewBag.idProblema = new SelectList(db.Problemas, "idProblema", "tipoProblema", chamado.idProblema);
            return View(chamado);
        }

        // GET: Chamado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.Chamadoes.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // POST: Chamado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chamado chamado = db.Chamadoes.Find(id);
            db.Chamadoes.Remove(chamado);
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
