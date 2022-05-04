using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AvailabilityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AvailabilityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Availability> objAvailabilityList = _unitOfWork.Availability.GetAll();
            return View(objAvailabilityList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Availability obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Availability.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = $"Ο τύπος διαθεσιμότητας {obj.Name} δημιουργήθηκε επιτυχώς";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var availabilityFromDbFirst = _unitOfWork.Availability.GetFirstOrDefault(u => u.Id == id);

            if (availabilityFromDbFirst == null)
            {
                return NotFound();
            }

            return View(availabilityFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Availability obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Availability.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = $"Ο τύπος διαθεσιμότητας {obj.Name} επεξεργάστηκε επιτυχώς";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        #region API CALLS
        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Availability.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Σφάλμα κατα τη διαγραφή του τύπου διαθεσιμότητας" });
            }

            _unitOfWork.Availability.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = $"Ο τύπος διαθεσιμότητας {obj.Name} διαγράφηκε";
            return Json(new { success = true, message = $"Ο τύπος διαθεσιμότητας {obj.Name} διαγράφηκε" });

        }
        #endregion
    }
}
