using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoNguyenTrongLib.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount
        {
            get
            {
                // Lấy OrderDetails từ DataContext  
                var details = DataContext.Instance.OrderDetails.Where(od => od.OrderID == this.OrderID);
                return details.Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount));
            }
        }
    }
}
