using ReminderMVC.Services.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMVC.Services.Entities
{
    public partial class ReminderDto : EntityBase
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string CronExpression { get; set; }

        public int? NumberOfTimes { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public virtual CategoryDto Category { get; set; }

        public static ReminderDto Build(int id, int categoryId, string description, DateTime startDate, string cronExpression, int? nmberOfTimes, bool enabled)
        {
            return new ReminderDto
            {
                Id = id,
                CategoryId = categoryId,
                Description = description,
                StartDate = startDate,
                CronExpression = cronExpression,
                NumberOfTimes = nmberOfTimes,
                Enabled = enabled,
                Category = null
            };
        }
    }
}
