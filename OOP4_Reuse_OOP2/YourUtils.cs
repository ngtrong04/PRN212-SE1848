using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP2;

namespace OOP4_Reuse_OOP2
{
    public static class YourUtils
    {
        public static int Tuoi(this Employee emp)
        {
            return DateTime.Now.Year - emp.Birthday.Year;
        }

        public static bool ThangSinhNhatCuaEmployee(this Employee emp)
        {
            return emp.Birthday.Month == DateTime.Now.Month;
        }
    }


}
