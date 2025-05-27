using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class ParttimeEmployee:Employee
    {
        public int WorkingHours { get; set; }

        public override double calSalary()
        {
            return WorkingHours * 100000;               // 100.000 đồng/giờ làm việc
        }
    }
}
