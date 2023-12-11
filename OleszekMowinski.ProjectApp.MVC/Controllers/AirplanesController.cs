using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OleszekMowinski.ProjectApp.BLC;
using OleszekMowinski.ProjectApp.Core;

namespace OleszekMowinski.ProjectApp.MVC.Controllers
{
    public class AirplanesController : Controller
    {
        //private readonly DataContext _context;
        private readonly BuisnessLogicComponent _blc;

        public AirplanesController(BuisnessLogicComponent buisnessLogicComponent)
        {
            _blc = buisnessLogicComponent;
        }

        // GET: Airplanes
        public IActionResult Index(AirplaneFilter filter)
        {
            var dataContext = _blc.GetFilteredAirplanes(filter).ToList();
            ViewData["ManufacturerId"] = new SelectList(_blc.GetManufacturers(), "Id", "Name");
            return View(dataContext);
        }

        // GET: Airplanes/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplane = _blc.GetAirplane(id.Value);
            if (airplane == null)
            {
                return NotFound();
            }

            return View(airplane);
        }

        // GET: Airplanes/Create
        public IActionResult Create()
        {
            ViewData["ManufacturerId"] = new SelectList(_blc.GetManufacturers(), "Id", "Name");
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string Name, DateTime Introduction, int Weight, AirplaneStatus Status, Guid ManufacturerId)
        {
            if (ModelState.IsValid)
            {
                _blc.CreateNewAirplane(Name, Introduction, Weight, Status, ManufacturerId);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_blc.GetManufacturers(), "Id", "Name", ManufacturerId);
            return View(new { Name, Introduction, Weight, Status, ManufacturerId });
        }

        // GET: Airplanes/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplane = _blc.GetAirplane((Guid)id);
            if (airplane == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(_blc.GetManufacturers(), "Id", "Name", airplane.ManufacturerId);
            return View(airplane);
        }

        // POST: Airplanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid Id, string Name, DateTime Introduction, int Weight, AirplaneStatus Status, Guid ManufacturerId)
        {
            if (ModelState.IsValid)
            {
                _blc.EditAirplane(Id, Name, Introduction, Weight, Status, ManufacturerId);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_blc.GetManufacturers(), "Id", "Name", ManufacturerId);
            return View(new { Id, Name, Introduction, Weight, Status, ManufacturerId });
        }

        // GET: Airplanes/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplane = _blc.GetAirplane((Guid)id);
            if (airplane == null)
            {
                return NotFound();
            }

            return View(airplane);
        }

        // POST: Airplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _blc.DeleteAirplane(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
