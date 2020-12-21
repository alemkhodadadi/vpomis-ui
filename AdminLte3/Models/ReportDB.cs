using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLte3.Models
{
    public class Task
    {
        public string Title { get; set; }
        public int TaskID { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Employee")]
        public Employee Employee { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Explaination { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Suggestion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Critic { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsSent { get; set; }
    }
    public class Category
    {
        public string CategoryTitle { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
        public int CategoryID { get; set; }
        public int Score { get; set; }
    }
    public class Department
    {
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<Category> Categories { get; set; }
    }

    public class Report
    {
        public int ReportID { get; set; }
        public Department Department { get; set; }
        public Employee Reporter { get; set; }
        public Periods Period { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<Task> Tasks { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsSent { get; set; }
    }

    public enum Periods
    {
        [Display(Name = "ماهانه")]
        monthly = 0,

        [Display(Name = "سه ماهه")]
        Trimester = 1,

        [Display(Name = "سالانه")]
        yearly = 2
    }
    
}
