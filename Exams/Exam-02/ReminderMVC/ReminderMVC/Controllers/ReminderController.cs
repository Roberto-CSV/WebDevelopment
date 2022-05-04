using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderMVC.Services;
using ReminderMVC.Models;
using System;
using System.Collections.Generic;

namespace ReminderMVC.Controllers
{
    public class ReminderController : Controller
    {
        private readonly IReminderService _reminderService;
        private readonly ICategorieService _categoryService;

        public ReminderController(IReminderService ReminderService, ICategorieService CategoryService)
        {
            _reminderService = ReminderService;
            _categoryService = CategoryService;
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
            return View(_reminderService.GetAll());
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View(_reminderService.GetById(id));
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, ReminderModel reminder)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _reminderService.Add(reminder);
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
        public ActionResult Edit(int id, ReminderModel reminder)
        {
            try
            {
                _reminderService.Update(id, reminder);
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
                _reminderService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
