using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UniinfoAsp.Models;

namespace UniinfoAsp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProblemaController : Controller
    {
        private UnipEntities db = new UnipEntities();

        // GET: Problema
        public ActionResult Index()
        {
            return View(db.Problemas.ToList());
        }


        // GET: Problema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Problema/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProblema,tipoProblema")] Problema problema)
        {
            if (ModelState.IsValid)
            {
                db.Problemas.Add(problema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problema);
        }

        public JsonResult problemaExistente(string tipoProblema)
        {
            return Json(!db.Problemas.Any(p => p.tipoProblema == tipoProblema), JsonRequestBehavior.AllowGet);
        }

        // GET: Problema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problema problema = db.Problemas.Find(id);
            if (problema == null)
            {
                return HttpNotFound();
            }
            return View(problema);
        }

        // POST: Problema/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProblema,tipoProblema")] Problema problema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(problema);
        }

        // GET: Problema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problema problema = db.Problemas.Find(id);
            if (problema == null)
            {
                return HttpNotFound();
            }
            return View(problema);
        }

        // POST: Problema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Problema problema = db.Problemas.Find(id);
            db.Problemas.Remove(problema);
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
