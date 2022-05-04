using ReminderMVC.Models;
using System.Collections.Generic;

namespace ReminderMVC.Services
{
    public interface ICategorieService
    {

        public void Add(CategoriesModel categories);
        public List<CategoriesModel> GetAll();
        public CategoriesModel GetById(int id);
        public void Delete(int id);
        public void Update(int id, CategoriesModel categories);
        public List<ReminderModel> GetAllByCategoryId(int id);


    }
}

