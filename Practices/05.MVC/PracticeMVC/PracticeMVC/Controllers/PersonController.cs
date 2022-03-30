using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeMVC.Models;

namespace PracticeMVC.Controllers
{
    public class PersonController : Controller
    {

        private static List<PersonModel> personList;

        public PersonController()
        {
            if (personList == null)
            {
                personList = new List<PersonModel>();
                personList = new List<PersonModel>()
                {
                  new PersonModel{Id=1, FirstName="Julio", LastName="Robles", DateOfBirth=new DateTime(1980,05,09), Sex='M'},
                  new PersonModel{Id=2, FirstName="Pilar", LastName="Lopez", DateOfBirth=new DateTime(1999,01,09), Sex='F'},
                  new PersonModel{Id=3, FirstName="Felipe", LastName="Daza", DateOfBirth=new DateTime(1985,08,09), Sex='M'},
                };

            }
        }

        // GET: Person
        public ActionResult Index()
        {
            return View(personList);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var personFound = personList.FirstOrDefault(u => u.Id == id);

            if (personFound == null)
            {
                return NotFound();
            }

            return View(personFound);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonModel person)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    person.Id = personList.Count + 1;
                    personList.Add(person);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var personFound = personList.FirstOrDefault(u => u.Id == id);

            if (personFound == null)
            {
                return NotFound();
            }

            return View(personFound);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonModel person)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var personFound = personList.FirstOrDefault(p => p.Id == person.Id);
                    personFound.FirstName = person.FirstName;
                    personFound.LastName = person.LastName;
                    personFound.DateOfBirth = person.DateOfBirth;
                    personFound.Sex = person.Sex;

                    return RedirectToAction(nameof(Index));
                }
                return View(person);
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var personFound = personList.FirstOrDefault(u => u.Id == id);

            if (personFound == null)
            {
                return NotFound();
            }

            return View(personFound);
        }

        // POST: Person/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PersonModel person)
        {
            try
            {
                // TODO: Add delete logic here
                var personFound = personList.FirstOrDefault(p => p.Id == person.Id);

                if (personFound == null)
                {
                    return View();
                }

                personList.Remove(personFound);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}