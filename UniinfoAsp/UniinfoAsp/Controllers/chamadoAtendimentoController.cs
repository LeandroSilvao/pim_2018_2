using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UniinfoAsp.Models;

namespace UniinfoAsp.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public ActionResult Encerrar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chamadoAtendimento chamadoAtendimento = db.chamadoAtendimentoes.Find(id);
            Chamado chamadoa = db.Chamadoes.Find(id);
            if (chamadoAtendimento == null)
            {
                return HttpNotFound();
            }
            return View(chamadoAtendimento);
        }


        [HttpPost, ActionName("Encerrar")]
        [ValidateAntiForgeryToken]
        public ActionResult EncerrarStatus(int id)
        {
            var chamadoAtendimento = db.chamadoAtendimentoes.Find(id);
            chamadoAtendimento.Chamado.statusAtendimento = "Encerrado";
            db.Entry(chamadoAtendimento).Property(ca => ca.dataAtendimento).CurrentValue = DateTime.Now;
            db.Entry(chamadoAtendimento.Chamado).Property(c => c.statusAtendimento).IsModified = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
