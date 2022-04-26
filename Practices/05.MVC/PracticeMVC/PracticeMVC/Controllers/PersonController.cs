using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeMVC.Models;
using PracticeMVC.Services;
using System;
using System.Collections.Generic;

namespace PracticeMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: PersonController
        public ActionResult Index()
        {
            return View(_personService.GetAll());
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View(_personService.GetById(id));
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonModel person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personService.Add(person);
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
        public ActionResult Edit(int id, PersonModel person)
        {
            try
            {
                _personService.Update(id, person);
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
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _personService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}