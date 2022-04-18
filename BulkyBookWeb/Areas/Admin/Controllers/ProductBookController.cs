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
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductBookController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        
        public IActionResult Index()
        {
            //IEnumerable<ProductBook> objProductBookList = _unitOfWork.ProductBook.GetAll();
            //return View(objProductBookList);
            return View();
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
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
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
        public IActionResult Upsert(ProductBookVM obj, IFormFile? file)
        {
            
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\books");
                    var extension = Path.GetExtension(file.FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.ProductBook.ImageUrl = @"\images\products\" + fileName + extension;

                }

                _unitOfWork.ProductBook.Add(obj.ProductBook);
                _unitOfWork.Save();
                TempData["success"] = $"Το βιβλίο {obj.ProductBook.Title} επεξεργάστηκε επιτυχώς";
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


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.ProductBook.GetAll(includeProperties: "Category,CoverType");

            return Json(new { data = productList });
        }


        #endregion
    }

}
