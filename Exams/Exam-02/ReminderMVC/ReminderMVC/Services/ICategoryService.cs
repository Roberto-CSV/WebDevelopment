using ReminderMVC.Models;
using System.Collections.Generic;

namespace ReminderMVC.Services
{
    public interface ICategoryService
    {
        public void Add(CategoryModel category);
        public List<CategoryModel> GetAll();
        public CategoryModel GetById(int id);
        public void Delete(int id);
        public void Update(int id, CategoryModel category);
    }
}
