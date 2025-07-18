using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessObjects.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime OrderDate { get; set; }


    // Tính tổng tiền từ các OrderDetails
    public decimal TotalAmount
    {
        get
        {
            // Nếu chưa có OrderDetails, trả về 0
            if (OrderDetails == null || !OrderDetails.Any())
                return 0;

            // Tính tổng tiền từng sản phẩm, có áp dụng giảm giá
            return OrderDetails.Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount));
        }
    }



    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
