using System.Net;
using System.Web.Mvc;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;
using UAI672_WEB.Services;

namespace UAI672_WEB.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IService<Addresses> _addressService;
        private readonly IService<Details> _detailService;

        public DetailsController()
        {
            _detailService = new DetailService(new DetailsRepository(new Model1()));
            _addressService = new AddressService(new AddressRepository(new Model1()));
        }

        // GET: Details
        public ActionResult Index()
        {
            var details = _detailService.GetAll();
            var addresses = _addressService.GetAll();
            return View(details);
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var details = _detailService.GetById(id.Value);
            if (details == null) return HttpNotFound();

            return View(details);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            ViewBag.Address = new SelectList(_addressService.GetAll(), "id", "City");
            return View();
        }

        // POST: Details/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,Address")] Details details)
        {
            if (ModelState.IsValid)
            {
                _detailService.Add(details);
                return RedirectToAction("Index");
            }

            ViewBag.Address = new SelectList(_addressService.GetAll(), "id", "City", details.Address);
            return View(details);
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var details = _detailService.GetById(id.Value);
            if (details == null) return HttpNotFound();

            ViewBag.Address = new SelectList(_addressService.GetAll(), "id", "City", details.Address);
            return View(details);
        }

        // POST: Details/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,Address")] Details details)
        {
            if (ModelState.IsValid)
            {
                _detailService.Update(details);
                return RedirectToAction("Index");
            }

            ViewBag.Address = new SelectList(_addressService.GetAll(), "id", "City", details.Address);
            return View(details);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var details = _detailService.GetById(id.Value);
            if (details == null) return HttpNotFound();

            return View(details);
        }

        // POST: Details/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _detailService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}