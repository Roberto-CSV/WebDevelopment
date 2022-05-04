using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderMVC.Models;
using ReminderMVC.Services;
using System;

namespace ReminderMVC.Controllers
{
    public class ReminderController : Controller
    {

        private readonly IReminderService _reminderService;

        private readonly ICategoryService _categoryService;

        public ReminderController(IReminderService reminderService, ICategoryService categoryService)
        {
            _reminderService = reminderService;
            _categoryService = categoryService;
        }
        // GET: ReminderController
        public ActionResult Index()
        {
            return View(_reminderService.GetAll());
        }

        // GET: ReminderController/Details/5
        public ActionResult Details(int id)
        {
            var reminder = _reminderService.GetById(id);
            return View(reminder);
        }

        // GET: ReminderController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ReminderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReminderModel reminder)
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

        // GET: ReminderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReminderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReminderModel reminder)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _reminderService.Update(id, reminder);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReminderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReminderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    