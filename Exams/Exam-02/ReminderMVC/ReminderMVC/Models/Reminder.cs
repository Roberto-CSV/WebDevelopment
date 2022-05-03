using System;
using System.ComponentModel.DataAnnotations;

namespace ReminderMVC.Models
{
    public class Reminder
    {
        [Required]
        public int Id { get; set; }

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
    }
}
