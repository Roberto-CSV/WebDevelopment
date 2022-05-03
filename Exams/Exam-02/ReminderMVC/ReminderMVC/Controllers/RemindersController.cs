using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReminderMVC.Configuration;
using ReminderMVC.Models;
using ReminderMVC.Services.Entities;
using ReminderMVC.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReminderMVC.Controllers
{
    public class RemindersController : Controller
    {
        private readonly ApiConfiguration _apiConfiguration;
        private RemindersService remindersService;

        public RemindersController(IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;
            remindersService = new RemindersService(_apiConfiguration.ApiRemindersAppUrl);
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<ReminderDto> reminders = await remindersService.GetAllAsync();
            IEnumerable<Reminder> reminderList = reminders.Select(reminderDto => ReminderDtoToReminder(reminderDto)).ToList();
            return View(reminderList);
        }

        // GET: CategoriesController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var categoryFound = await remindersService.GetByIdAsync(id);
            if (categoryFound == null)
            {
                return NotFound();
            }
            var reminder = ReminderDtoToReminder(categoryFound);
            return View(reminder);
        }

        // GET: CategoriesController1/Details/5
        public async Task<ActionResult> RemindersByCategory(int categoryId)
        {
            IEnumerable<ReminderDto> reminders = await remindersService.GetAllByCategoryId(categoryId);
            IEnumerable<Reminder> reminderList = reminders.Select(reminderDto => ReminderDtoToReminder(reminderDto)).ToList();
            return View(reminderList);
        }

        public async Task DeleteByCategory(int categoryId)
        {
            await remindersService.DeleteByCategoryIdAsync(categoryId);
        }

        // GET: CategoriesController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Reminder reminder)
        {
            try
            {
                if (ModelState.IsValid && reminder.NumberOfTimes >=0 && reminder.StartDate >= DateTime.Now)
                {
                    var categoryAdded = await remindersService.AddAsync(ReminderToReminderDto(reminder));
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
            var categoryFound = await remindersService.GetByIdAsync(id);
            if (categoryFound == null)
            {
                return NotFound();
            }
            var categoryFounded = ReminderDtoToReminder(categoryFound);
            return View(categoryFounded);
        }

        // POST: CategoriesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Reminder reminder)
        {
            try
            {
                if (ModelState.IsValid && reminder.NumberOfTimes >= 0 && reminder.StartDate >= DateTime.Now)
                {
                    var categoryModified = await remindersService.UpdateAsync(ReminderToReminderDto(reminder));
                    return RedirectToAction(nameof(Index));
                }
                return View(reminder);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var categoryFound = await remindersService.GetByIdAsync(id);
            if (categoryFound == null)
            {
                return NotFound();
            }
            var reminder = ReminderDtoToReminder(categoryFound);
            return View(reminder);
        }

        // POST: CategoriesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Reminder reminder)
        {
            try
            {
                var categoryFound = await remindersService.GetByIdAsync(reminder.Id);
                if (categoryFound == null)
                {
                    return View();
                }
                var categoryDeleted = await remindersService.DeleteAsync(reminder.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Reminder ReminderDtoToReminder(ReminderDto reminderDto)
        {
            return new Reminder
            {
                Id = reminderDto.Id,
                CategoryId = reminderDto.CategoryId,
                Description = reminderDto.Description,
                StartDate = reminderDto.StartDate,
                CronExpression = reminderDto.CronExpression,
                NumberOfTimes = reminderDto.NumberOfTimes,
                Enabled = reminderDto.Enabled
            };
        }

        private ReminderDto ReminderToReminderDto(Reminder reminder)
        {
            return ReminderDto.Build
            (
                reminder.Id,
                reminder.CategoryId,
                reminder.Description,
                reminder.StartDate,
                reminder.CronExpression,
                reminder.NumberOfTimes,
                reminder.Enabled
            );
        }
    }
}
