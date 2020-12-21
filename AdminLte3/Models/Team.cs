using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLte3.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public Employee Manager { get; set; }
        public List<Employee> Employees { get; set; }
        public ICollection<Todo> Todos { get; set; }
        

    }
}
