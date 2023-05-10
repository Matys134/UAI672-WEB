using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;
using UAI672_WEB.Services;
using UAI672_WEB.Views.DetailsView;

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
        public async Task<ActionResult> Index()
        {
            var details = await _detailService.GetAllAsync();
            var addresses = await _addressService.GetAllAsync();
            return View(details);
        }

        // GET: Details/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var detail = await _detailService.GetByIdAsync(id.Value);
            if (detail == null) return HttpNotFound();

            return View(detail);
        }

        // GET: Details/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Address = new SelectList(await _addressService.GetAllAsync(), "id", "City");
            return View();
        }

        // POST: Details/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Details detailModel)
        {
            if (ModelState.IsValid)
            {
                var detail = new Details
                {
                    Name = detailModel.Name,
                    Surname = detailModel.Surname,
                    Address = detailModel.Address
                };
                await _detailService.AddAsync(detail);
                return Json(detail);
            }

            return Json(new { error = "Invalid model state" });
        }

        // GET: Details/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var details = await _detailService.GetByIdAsync(id.Value);
            if (details == null) return HttpNotFound();

            ViewBag.Address = new SelectList(await _addressService.GetAllAsync(), "id", "City", details.Address);
            return View(details);
        }

        // POST: Details/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Surname,Address")] Details details)
        {
            if (ModelState.IsValid)
            {
                await _detailService.UpdateAsync(details);
                return RedirectToAction("Index");
            }

            ViewBag.Address = new SelectList(await _addressService.GetAllAsync(), "id", "City", details.Address);
            return View(details);
        }

        // GET: Details/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var details = await _detailService.GetByIdAsync(id.Value);
            if (details == null) return HttpNotFound();

            return View(details);
        }

        // POST: Details/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _detailService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}