using System.ComponentModel.DataAnnotations;

namespace ReminderMVC.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
