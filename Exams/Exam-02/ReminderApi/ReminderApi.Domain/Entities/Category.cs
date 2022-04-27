using ReminderApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApi.Domain.Entities
{
    public class Category : EntityBase
    {
        [Required]
        public string Description { get; set; }
    }
}
