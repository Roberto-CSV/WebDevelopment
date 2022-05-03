using ReminderMVC.Services.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMVC.Services.Entities
{
    public partial class CategoryDto : EntityBase
    {
        public CategoryDto()
        {
            this.Reminders = new HashSet<ReminderDto>();
        }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<ReminderDto> Reminders { get; set; }

        public static CategoryDto Build(int id, string description)
        {
            return new CategoryDto
            {
                Id = id,
                Description = description,
                Reminders = new HashSet<ReminderDto>()
            };
        }
    }
}
