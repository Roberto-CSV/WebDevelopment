using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReminderMVC.Configuration;
using ReminderMVC.Models;
using ReminderMVC.Services;
using ReminderMVC.Services.Entities;
using ReminderMVC.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReminderMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApiConfiguration _apiConfiguration;
        private CategoriesService categoriesService;
        private RemindersService remindersService;

        public CategoriesController(IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;
            categoriesService = new CategoriesService(_apiConfiguration.ApiRemindersAppUrl);
            remindersService = new RemindersService(_apiConfiguration.ApiRemindersAppUrl);
        }

        // GET: CategoriesController1
        public async Task<ActionResult> Index()
        {
            IEnumerable<CategoryDto> categories = await categoriesService.GetAllAsync();
            IEnumerable<Category> categoryList = categories.Select(categoryDto => CategoryDtoToCategory(categoryDto)).ToList();
            return View(categoryList);
        }

        // GET: CategoriesController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var categoryFound = await categoriesService.GetByIdAsync(id);
            if (categoryFound == null)
            {
                return NotFound();
            }
            var category = CategoryDtoToCategory(categoryFound);
            return View(category);
        }

        // GET: CategoriesController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var categoryAdded = await categoriesService.AddAsync(CategoryToCategoryDto(category));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController1/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var categoryFound = await categoriesService.GetByIdAsync(id);
            if (categoryFound == null)
            {
                return NotFound();
            }
            var categoryFounded = CategoryDtoToCategory(categoryFound);
            return View(categoryFounded);
        }

        // POST: CategoriesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoryModified = await categoriesService.UpdateAsync(CategoryToCategoryDto(category));
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var categoryFound = await categoriesService.GetByIdAsync(id);
            if (categoryFound == null)
            {
                return NotFound();
            }
            var category = CategoryDtoToCategory(categoryFound);
            return View(category);
        }

        // POST: CategoriesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Category category)
        {
            try
            {
                var categoryFound = await categoriesService.GetByIdAsync(category.Id);
                if (categoryFound == null)
                {
                    return View();
                }
                var categoryDeleted = await categoriesService.DeleteAsync(category.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Category CategoryDtoToCategory(CategoryDto categoryDto)
        {
            return new Category
            {
                Id = categoryDto.Id,
                Description = categoryDto.Description
            };
        }

        private CategoryDto CategoryToCategoryDto(Category category)
        {
            return CategoryDto.Build
            (
                category.Id, 
                category.Description
            );
        }
    }
}
