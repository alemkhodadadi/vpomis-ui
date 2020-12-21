using AdminLte3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLte3.ViewModels
{
    public class TodoViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title can not bet shorter than 3 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        public string TodoType { get; set; }
        public Boolean HasReminder { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Reminder Time")]
        public DateTime ReminderTime { get; set; }
        public Boolean Teamwork { get; set; }
        public List<Employee> Teammates { get; set; }
        public Boolean HasExplanation { get; set; }
        public string Explanation { get; set; }
    }
}
