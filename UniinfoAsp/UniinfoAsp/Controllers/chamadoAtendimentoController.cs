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
    public class chamadoAtendimentoController : Controller
    {
        private UnipEntities db = new UnipEntities();

        // GET: chamadoAtendimento
        public ActionResult Index()
        {
            var chamadoAtendimentoes = db.chamadoAtendimentoes.Include(c => c.Chamado).Include(c => c.Funcionario);
            var chamAtend = chamadoAtendimentoes.Where(ca => ca.Chamado.statusAtendimento.Equals("Em andamento"));
            return View(chamAtend.ToList());
        }

        // GET: chamadoAtendimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chamadoAtendimento chamadoAtendimento = db.chamadoAtendimentoes.Find(id);
            if (chamadoAtendimento == null)
            {
                return HttpNotFound();
            }
            return View(chamadoAtendimento);
        }

        // GET: chamadoAtendimento/Create
        public ActionResult Create()
        {
            ViewBag.idChamado = new SelectList(db.Chamadoes, "idChamado", "descricao");
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome");
            return View();
        }

        // POST: chamadoAtendimento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAtendimento,idFuncionario,idChamado,dataAtendimento")] chamadoAtendimento chamadoAtendimento)
        {
            if (ModelState.IsValid)
            {
                db.chamadoAtendimentoes.Add(chamadoAtendimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idChamado = new SelectList(db.Chamadoes, "idChamado", "descricao", chamadoAtendimento.idChamado);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", chamadoAtendimento.idFuncionario);
            return View(chamadoAtendimento);
        }

        // GET: chamadoAtendimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chamadoAtendimento chamadoAtendimento = db.chamadoAtendimentoes.Find(id);
            if (chamadoAtendimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idChamado = new SelectList(db.Chamadoes, "idChamado", "descricao", chamadoAtendimento.idChamado);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", chamadoAtendimento.idFuncionario);
            return View(chamadoAtendimento);
        }

        // POST: chamadoAtendimento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAtendimento,idFuncionario,idChamado,dataAtendimento")] chamadoAtendimento chamadoAtendimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamadoAtendimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idChamado = new SelectList(db.Chamadoes, "idChamado", "descricao", chamadoAtendimento.idChamado);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", chamadoAtendimento.idFuncionario);
            return View(chamadoAtendimento);
        }

        // GET: chamadoAtendimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chamadoAtendimento chamadoAtendimento = db.chamadoAtendimentoes.Find(id);
            if (chamadoAtendimento == null)
            {
                return HttpNotFound();
            }
            return View(chamadoAtendimento);
        }

        // POST: chamadoAtendimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chamadoAtendimento chamadoAtendimento = db.chamadoAtendimentoes.Find(id);
            db.chamadoAtendimentoes.Remove(chamadoAtendimento);
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
