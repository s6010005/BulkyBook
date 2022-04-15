using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Controllers
{
    public class ProductBookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductBookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            IEnumerable<ProductBook> objProductBookList = _unitOfWork.ProductBook.GetAll();
            return View(objProductBookList);
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            ProductBookVM productBookVM = new()
            {
                ProductBook = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                overTypeList = _unitOfWork.CoverType.GetAll().Select(
                c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            //Xwris ViewModel
            //ProductBook productBook = new();
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
            //    c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.Id.ToString()
            //    });
            //IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
            //    c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.Id.ToString()
            //    });
            if (id == null || id == 0)
            {
                //create book

                //xwirs ViewModel
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(productBookVM);
            }
            else
            {
                //update book
            }


            return View(productBookVM);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductBook obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductBook.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = $"Το βιβλίο {obj.Title} επεξεργάστηκε επιτυχώς";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productBookFromDbFirst = _unitOfWork.ProductBook.GetFirstOrDefault(u => u.Id == id);

            if (productBookFromDbFirst == null)
            {
                return NotFound();
            }

            return View(productBookFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.ProductBook.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductBook.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = $"Το βιβλίο  {obj.Title} διαγράφηκε";
            return RedirectToAction("Index");

        }
    }
}
