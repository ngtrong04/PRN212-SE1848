using System.Text;
using DemoLinQ2SQL;

Console.OutputEncoding = Encoding.UTF8;

// khai báo chuỗi kết nối tới CSDL:
string connectionString = "server=localhost;database=MyStore;uid=sa;password=12345";
MyStoreDataContext context = new MyStoreDataContext(connectionString);
//câu 1:Truy vấn toàn bộ danh mục
var dsdm = context.Categories.ToList();
Console.WriteLine("---Danh sách danh mục---");
foreach (var d in dsdm)
    Console.WriteLine(d.CategoryID + "\t" + d.CategoryName);

// câu 2: Lấy thông tin chi tiết danh mục khi biết mã
int madm = 7;
Category cate = context.Categories.FirstOrDefault(c => c.CategoryID == madm);
if (cate == null )
{
    Console.WriteLine("Không tìm thấy danh mục có mã = " + madm);
}
else
{
    Console.WriteLine("Tìm thấy danh mục có mã = " + madm);
    Console.WriteLine(cate.CategoryID + "\t" + cate.CategoryName);
}

// câu 3 : dùng query syntax để truy vấn toàn bộ sản phẩm
var dssp = from p in context.Products
           select p;
Console.WriteLine("---Danh sách sản phẩm:---");
foreach (var p in dssp)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}

// câu 4: Dùng query syntax và anonymous type để lọc ra các sản phẩm nhưng chỉ lấy mã và đơn giá sản phẩm đồng thời sắp xếp giảm dần.

var dssp4 = from p in context.Products
            orderby p.UnitPrice descending
            select new { p.ProductID, p.UnitPrice };
Console.WriteLine("---Câu 4: Danh sách sản phẩm sắp xếp giảm dần theo đơn giá:---");
foreach (var p in dssp4)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice);
}
// câu 5: Sửa câu 4 theo extension method (Method syntax)
var dssp5 = context.Products.OrderByDescending(p => p.UnitPrice)
                            .Select(p => new { p.ProductID, p.UnitPrice });
Console.WriteLine("---Câu 5: Danh sách sản phẩm sắp xếp giảm dần theo đơn giá (Method syntax):---");
foreach (var p in dssp5)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice);
}
// Lọc ra top 3 sản phẩm có đơn giá lớn nhất hệ thống yêu cầu dùng method syntax
var dssp6 = context.Products.OrderByDescending(p => p.UnitPrice)
                            .Take(3)
                            .Select(p => new { p.ProductID, p.ProductName, p.UnitPrice });
Console.WriteLine("---Câu 6: Danh sách top 3 sản phẩm có đơn giá lớn nhất:---");
foreach (var p in dssp6)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice + "\t\t" +  p.ProductName);
}

// câu 7: Sửa tên danh mục khi biết mã
int madm7_edit = 3;
Category cate_edit = context.Categories.FirstOrDefault(c => c.CategoryID == madm7_edit);
if (cate_edit != null)
{
    cate_edit.CategoryName = "Hàng trôi nổi";
    context.SubmitChanges();
    Console.WriteLine("Đã sửa tên danh mục có mã = " + madm7_edit);
}
else
{
    Console.WriteLine("Không tìm thấy danh mục có mã = " + madm7_edit);
}

//câu 8: xóa danh mục khi biết mã   ==> XEM XÉT
int madm_delete = 15;
Category cate_remove = context.Categories.FirstOrDefault(c => c.CategoryID == madm_delete);
if (cate_remove != null)
{
    context.Categories.DeleteOnSubmit(cate_remove);
    context.SubmitChanges();
    Console.WriteLine("Đã xóa danh mục có mã = " + madm_delete);
}
else
{
    Console.WriteLine("Không tìm thấy danh mục có mã = " + madm_delete);
}

// câu 9 : xóa các danh mục nếu không có bất kì sản phẩm
// lưu ý: là xoas cùng 1 lúc nhiều danh mục, mà các dnah mục này không có chứa bất kỳ 1 sản phẩm nào

var dsdm9 = context.Categories.Where(c => !c.Products.Any()).ToList();
if (dsdm9.Count > 0)
{
    context.Categories.DeleteAllOnSubmit(dsdm9);
    context.SubmitChanges();
    Console.WriteLine("Đã xóa " + dsdm9.Count + " danh mục không có sản phẩm.");
}
else
{
    Console.WriteLine("Không có danh mục nào không có sản phẩm để xóa.");
}

// câu 10: thêm mới 1 danh mục
Category c_new = new Category();
c_new.CategoryName = "Hàng Lậu từ Trung Quốc";
context.Categories.InsertOnSubmit(c_new);
context.SubmitChanges();

// câu 11:thêm mới nhiều danh mục
List<Category> list = new List<Category>();
list.Add(new Category { CategoryName = "Hàng gia dụng" });
list.Add(new Category { CategoryName = "Hàng điện tử" });
list.Add(new Category { CategoryName = "Hàng phụ kiện" });
list.Add(new Category { CategoryName = "Hàng giả" });
context.Categories.InsertAllOnSubmit(list);
context.SubmitChanges();