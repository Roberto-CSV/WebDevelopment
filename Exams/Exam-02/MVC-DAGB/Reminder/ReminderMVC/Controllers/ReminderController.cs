using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderMVC.Models;
using ReminderMVC.Services;
using System;
using System.Collections.Generic;

namespace ReminderMVC.Controllers
{
    public class ReminderController : Controller
    {
        private readonly IReminderService _reminderService;
        private readonly ICategorieService _categorieService;

        public ReminderController(IReminderService reminderService, ICategorieService categorieService)
        {
            _reminderService = reminderService;
            _categorieService = categorieService;
        }


        // GET: ReminderController
        public ActionResult Index()
        {
            return View(_reminderService.GetAll());
        }

        // GET: ReminderController/Details/5
        public ActionResult Details(int id)
        {
            return View(_reminderService.GetById(id));
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
                _reminderService.Add(reminder);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.MessageCategoryInvalid = "El ID de la categoria no existe.";
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
        public ActionResult Edit(ReminderModel reminder)
        {
            try
            {
                _reminderService.Update(reminder);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.MessageCategoryInvalid = "El ID de la categoria no existe.";
                return View();
            }
        }

        // GET: ReminderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_reminderService.GetById(id));
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
