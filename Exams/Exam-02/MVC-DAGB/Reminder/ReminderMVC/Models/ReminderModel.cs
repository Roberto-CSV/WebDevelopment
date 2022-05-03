using System;

namespace ReminderMVC.Models
{
    public class ReminderModel
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public string CronExpression { get; set; }

        public int NumberOfTimes { get; set; }

        public bool Enabled { get; set; }

    }
}
