using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderMVC.Models;
using ReminderMVC.Services;

namespace ReminderMVC.Controllers
{
    public class CategoryController : Controller
    {


        private readonly ICategoryService _categoryService;
        private readonly IReminderService _reminderService;

        public CategoryController(ICategoryService categoryService, IReminderService reminderService)
        {
            _categoryService = categoryService;
            _reminderService = reminderService;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {

            var category = _categoryService.GetById(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.Add(category);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryModel category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.Update(id, category);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _categoryService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult ReminderByCategoryId(int id)
        {
            return View(_reminderService.Find(id));
        }



    }
}
