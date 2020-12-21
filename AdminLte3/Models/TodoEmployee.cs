using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLte3.Models
{
    public class TodoEmployee
    {
        public int TodoID { get; set; }
        public int EmployeeID { get; set; }
        public virtual Todo Todo { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
    