using System.Text;
using Lucy_SalesDataManagement;

Console.OutputEncoding = Encoding.UTF8;

// khai báo chuỗi kết nối tới CSDL:
string connectionString = "server=localhost;database=Lucy_SalesData;uid=sa;password=12345";
Lucy_SalesDataDataContext context = new Lucy_SalesDataDataContext(connectionString);

// câu 1: lọc ra danh sách khách hàng
var dskh = context.Customers.ToList();
Console.WriteLine("---Danh sách khách hàng---");
foreach (var kh in dskh)
{
    Console.WriteLine(kh.CustomerID + "\t" + kh.CompanyName + "\t" + kh.ContactName);
}   

// câu 2: tìm chi tiết thông tin khách hàng
//khi biết mã khách hàng
int makh = 10;
Customer cust = context.Customers.FirstOrDefault(c => c.CustomerID == makh);
if (cust != null)
{
    Console.WriteLine("Thông tin chi tiết khách hàng có mã " + makh + ":");
    Console.WriteLine(cust.CustomerID + "\t" + cust.CompanyName + "\t" + cust.ContactName);
}
else
{
    Console.WriteLine("Không tìm thấy khách hàng có mã " + makh);
}

// câu 3: từ kết quả câu 2 : lọc ra danh sách các hóa đơn của khách hàng
// các cột dữ liệu gồm: Mã hóa đơn + ngày hóa đơn

var dsHoaDon = context.Orders
    .Where(o => o.CustomerID == makh)
    .Select(o => new { o.OrderID, o.OrderDate })
    .ToList();
Console.WriteLine("---Danh sách hóa đơn của khách hàng có mã " + makh + ":---");
foreach (var hd in dsHoaDon)
{
    Console.WriteLine(hd.OrderID + "\t" + hd.OrderDate);
}

// câu 4: từ kết quả của câu 3 bổ sung thêm trị giá của mỗi hóa đơn
if (cust != null)
{
    var dshd = context.Orders
        .Where(o => o.CustomerID == makh)
        .Select(o => new
        {
            o.OrderID,
            o.OrderDate,
            TotalValue = o.Order_Details.Sum(od => od.UnitPrice * od.Quantity * (1 -(decimal)od.Discount))
        })
        .ToList();
    Console.WriteLine("---Danh sách hóa đơn của khách hàng có mã " + makh + " với trị giá:---");
    foreach (var hd in dshd)
    {
        Console.WriteLine(hd.OrderID + "\t" + hd.OrderDate.ToString("dd/MM/yyyy") + "\t" + hd.TotalValue);
    }
}