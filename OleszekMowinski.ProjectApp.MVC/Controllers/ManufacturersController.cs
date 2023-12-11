using Microsoft.AspNetCore.Mvc;
using OleszekMowinski.ProjectApp.BLC;

namespace OleszekMowinski.ProjectApp.MVC.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly BuisnessLogicComponent _blc;

        public ManufacturersController(BuisnessLogicComponent buisnessLogicComponent)
        {
            _blc = buisnessLogicComponent;
        }

        // GET: Manufacturers
        public IActionResult Index()
        {
            return View(_blc.GetManufacturers());
        }

        // GET: Manufacturers/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _blc.GetManufacturer((Guid)id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // GET: Manufacturers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufacturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string Name, DateTime Founded, string Headquarters, string President)
        {
            if (ModelState.IsValid)
            {
                _blc.CreateNewManufacturer(Name, Founded, Headquarters, President);
                return RedirectToAction(nameof(Index));
            }
            return View(new { Name, Founded, Headquarters, President });
        }

        // GET: Manufacturers/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _blc.GetManufacturer((Guid)id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid Id, string Name, DateTime Founded, string Headquarters, string President)
        {

            if (ModelState.IsValid)
            {
                _blc.EditManufacturer(Id, Name, Founded, Headquarters, President);
                return RedirectToAction(nameof(Index));
            }
            return View(new { Name, Founded, Headquarters, President });
        }

        // GET: Manufacturers/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _blc.GetManufacturer((Guid)id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _blc.DeleteManufacturer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
