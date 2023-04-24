using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UAI672_WEB.Models;

namespace UAI672_WEB.Controllers
{
    public class DetailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Details
        public ActionResult Index()
        {
            var details = db.Details.Include(d => d.Addresses);
            return View(details.ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            ViewBag.Address = new SelectList(db.Addresses, "id", "City");
            return View();
        }

        // POST: Details/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž 
        // chcete vytvořit vazbu. Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,Address")] Details details)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Address = new SelectList(db.Addresses, "id", "City", details.Address);
            return View(details);
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Address = new SelectList(db.Addresses, "id", "City", details.Address);
            return View(details);
        }

        // POST: Details/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž 
        // chcete vytvořit vazbu. Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,Address")] Details details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Address = new SelectList(db.Addresses, "id", "City", details.Address);
            return View(details);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Details details = db.Details.Find(id);
            db.Details.Remove(details);
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
