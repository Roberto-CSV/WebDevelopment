using ReminderMVC.Models;
using System.Collections.Generic;

namespace ReminderMVC.Services
{
    public interface ICategorieService
    {
        public void Add(CategorieModel category);

        public List<CategorieModel> GetAll();

        public CategorieModel GetById(int id);

        public void Delete(int id);

        public void Update(CategorieModel category);
    }
}
