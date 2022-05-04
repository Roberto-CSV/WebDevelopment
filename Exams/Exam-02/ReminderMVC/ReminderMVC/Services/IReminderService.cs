using ReminderMVC.Models;
using System.Collections.Generic;

namespace ReminderMVC.Services
{
    public interface IReminderService
    {

        public void Add(ReminderModel reminder);
        public List<ReminderModel> GetAll();
        public ReminderModel GetById(int id);
        public void Delete(int id);
        public void Update(int id, ReminderModel reminder);
        public List<ReminderModel> GetAllByCategoryId(int id);

    }
}

