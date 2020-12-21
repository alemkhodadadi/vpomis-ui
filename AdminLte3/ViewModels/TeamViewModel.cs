using AdminLte3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLte3.ViewModels
{
    public class TeamViewModel
    {
        public int TeamID { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Todo> Todos { get; set; }

    }
}
