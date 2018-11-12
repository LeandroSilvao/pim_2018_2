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
    public class ChamadoController : Controller
    {
        private UnipEntities db = new UnipEntities();

        // GET: Chamado
        public ActionResult Index()
        {
            var chamadoes = db.Chamadoes.Include(c => c.Funcionario).Include(c => c.Problema);
            var cham = chamadoes.Where(c => c.statusAtendimento.Equals("Aberto"));
            return View(cham.ToList());
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

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public ActionResult DetailsDeleteConfirmed(int id)
        {
            Chamado chamado = db.Chamadoes.Find(id);
            db.Chamadoes.Remove(chamado);
            db.SaveChanges();
            return RedirectToAction("Index");
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

        public ActionResult Posicionar(int? id)
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

        [HttpPost, ActionName("Posicionar")]
        [ValidateAntiForgeryToken]
        public ActionResult posicionarStatus(int id)
        {
            var chamado = db.Chamadoes.Find(id);
            chamado.statusAtendimento = "Em andamento";
            db.Chamadoes.Attach(chamado);
            db.Entry(chamado).Property(c => c.statusAtendimento).IsModified = true;
            db.SaveChanges();

            chamadoAtendimento ca = new chamadoAtendimento();
            ca.idChamado = chamado.idChamado;
            ca.idFuncionario = chamado.Funcionario.idFuncionario;
            db.chamadoAtendimentoes.Add(ca);
            db.SaveChanges();
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
