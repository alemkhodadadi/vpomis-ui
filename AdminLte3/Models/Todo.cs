using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLte3.Models
{
    public class Todo
    {
        [Key]
        public int TodoID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title can not be shorter than 3 characters.")]
        [Display(Name = "Title")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public TodoType? TodoType { get; set; }
        public Boolean IsUrgent { get; set; }
        public TodoStatus TodoStatus { get; set; }
        public Boolean HasReminder { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Reminder Time")]
        public DateTime ReminderTime { get; set; }
        public Boolean Teamwork { get; set; }
        public Boolean HasExplanation { get; set; }
        public string Explanation { get; set; }
        public virtual IList<TodoEmployee> Teammates { get; set; }
    }

    public enum TodoType
    {
        [Display(Name = "یادداشت معمولی")]
        Note = 1,
        [Display(Name = "تعقیبی")]
        Procedure = 2,
        [Display(Name = "شخصی")]
        Personal = 3,
        [Display(Name = "دفتری")]
        Office = 4
    }

    public enum TodoStatus
    {
        [Display(Name = "تحت کار")]
        Open = 0,
        [Display(Name = "اتمام")]
        Done = 1,
        [Display(Name = "لغو")]
        Cancel = 2,
        [Display(Name = "تاریخ گذشته")]
        Expired = 3
    }
}
