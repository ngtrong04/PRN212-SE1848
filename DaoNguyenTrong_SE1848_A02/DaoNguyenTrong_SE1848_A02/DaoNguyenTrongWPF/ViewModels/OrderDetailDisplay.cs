using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class OrderDetailDisplay
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
    }
}
