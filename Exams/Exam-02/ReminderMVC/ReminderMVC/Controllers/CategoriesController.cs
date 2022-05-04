using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderMVC.Services;
using ReminderMVC.Models;
using System;
using System.Collections.Generic;

namespace ReminderMVC.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategorieService _categoryService;
        private readonly IReminderService _reminderService;

        public CategorieController(ICategorieService CategorieService, IReminderService ReminderService)
        {
            _categoryService = CategorieService;
            _reminderService = ReminderService;
        }


        public ActionResult GetByCategoryId()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        //POST: MultiplesObjetosVistas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetByCategoryId(int id)
        {

            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Reminders = _reminderService.GetAllByCategoryId(id);
            return View(_reminderService.GetAllByCategoryId(id));
        }
        // GET: PersonController
        public ActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View(_categoryService.GetById(id));
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, CategoriesModel category)
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

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriesModel category)
        {
            try
            {
                _categoryService.Update(id, category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection description)
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
    }
}
