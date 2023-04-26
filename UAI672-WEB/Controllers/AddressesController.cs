using System.Net;
using System.Web.Mvc;
using UAI672_WEB.Models;
using UAI672_WEB.Services;

namespace UAI672_WEB.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // Parameterless constructor added to fix error
        public AddressesController()
        {
            _addressService = new AddressService(new AddressRepository(new Model1()));
        }

        // GET: Addresses
        public ActionResult Index()
        {
            var addresses = _addressService.GetAllAddresses();
            return View(addresses);
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var addresses = _addressService.GetAddressById(id.Value);
            if (addresses == null)
                return HttpNotFound();

            return View(addresses);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž
        // chcete vytvořit vazbu. Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                _addressService.AddAddress(addresses);
                return RedirectToAction("Index");
            }

            return View(addresses);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var addresses = _addressService.GetAddressById(id.Value);
            if (addresses == null)
                return HttpNotFound();

            return View(addresses);
        }

        // POST: Addresses/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž
        // chcete vytvořit vazbu. Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                _addressService.UpdateAddress(addresses);
                return RedirectToAction("Index");
            }

            return View(addresses);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var addresses = _addressService.GetAddressById(id.Value);
            if (addresses == null)
                return HttpNotFound();

            return View(addresses);
        }

        // POST: Addresses/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _addressService.DeleteAddress(id);
            return RedirectToAction("Index");
        }
    }
}