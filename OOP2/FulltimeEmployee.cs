using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class FulltimeEmployee:Employee
    {
        public override double calSalary()
        {
            return base.calSalary() + 5000000;              // 4 triệu lương cơ bản + 5 triệu phụ cấp
        }
    }
}
