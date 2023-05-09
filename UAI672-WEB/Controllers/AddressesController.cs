using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using UAI672_WEB.Models;
using UAI672_WEB.Services;
using UAI672_WEB.Views.Addresses;

namespace UAI672_WEB.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IService<Addresses> _addressService;

        public AddressesController(IService<Addresses> addressService)
        {
            _addressService = addressService;
        }

        // Parameterless constructor added to fix error
        public AddressesController()
        {
            _addressService = new AddressService(new AddressRepository(new Model1()));
        }

        // GET: Addresses
        public async Task<ActionResult> Index()
        {
            var addresses = await _addressService.GetAllAsync();
            return View(addresses);
        }

        // GET: Addresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Addresses address = await _addressService.GetByIdAsync(id.Value);
            if (address == null)
                return HttpNotFound();

            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create([Bind(Include = "City, Number")] AddressesModelView viewModel)
        {
            if (ModelState.IsValid)
            {
                var address = new Addresses()
                {
                    City = viewModel.City,
                    Number = viewModel.Number
                };

                _addressService.AddAsync(address);
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Addresses/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž
        // chcete vytvořit vazbu. Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(AddressesModelView viewModel)
        {
            if (ModelState.IsValid)
            {
                var address = new Addresses()
                {
                    City = viewModel.City,
                    Number = viewModel.Number
                };

                await _addressService.AddAsync(address);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Addresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var address = await _addressService.GetByIdAsync(id.Value);
            if (address == null)
                return HttpNotFound();

            var viewModel = new AddressesModelView()
            {
                Id = address.Id,
                City = address.City,
                Number = address.Number
            };

            return View(address);
        }

        // POST: Addresses/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž
        // chcete vytvořit vazbu. Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AddressesModelView viewModel)
        {
            if (ModelState.IsValid)
            {
                var address = new Addresses()
                {
                    Id = viewModel.Id,
                    City = viewModel.City,
                    Number = viewModel.Number
                };

                await _addressService.UpdateAsync(address);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Addresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var address = await _addressService.GetByIdAsync(id.Value);
            if (address == null)
                return HttpNotFound();

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _addressService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}