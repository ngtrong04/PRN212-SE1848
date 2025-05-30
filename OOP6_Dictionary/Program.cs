using System.Text;
using OOP6_Dictionary;

Console.OutputEncoding = Encoding.UTF8;


Category c1 = new Category();
c1.Id = 1;
c1.Name = "Nước ngọt";

Product p1 = new Product();
p1.Id = 1;
p1.Name = "Pepsi";
p1.Quantity = 10;
p1.Price = 30;
c1.AddProduct(p1);

Product p2 = new Product();
p2.Id = 2;
p2.Name = "Coca";
p2.Quantity = 7;
p2.Price = 25;
c1.AddProduct(p2);

Product p3 = new Product();
p3.Id = 3;
p3.Name = "7 Up";
p3.Quantity = 5;
p3.Price = 20;
c1.AddProduct(p3);

Product p4 = new Product();
p4.Id = 4;
p4.Name = "Sting";
p4.Quantity = 18;
p4.Price = 15;
c1.AddProduct(p4);

Product p5 = new Product();
p5.Id = 5;
p5.Name = "RedBull";
p5.Quantity = 12;
p5.Price = 50;
c1.AddProduct(p5);

Console.WriteLine("--Thông tin danh mục--:");
Console.WriteLine(c1);
Console.WriteLine("--Thông tin các sản phẩm trong danh mục--:");
c1.PrintAllProducts();

double min_price = 10;
double max_price = 30;
Dictionary<int, Product> products_by_price = c1.FilterProductsByPrice(min_price, max_price);
Console.WriteLine($"Danh sách sản phẩm có giá từ {min_price} tới {max_price}");
foreach(KeyValuePair<int, Product> kvp in products_by_price)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sorted_products = c1.SortProductsByPrice();
Console.WriteLine("--Danh sách sản phẩm sau khi sắp xếp giá tăng dần");
foreach (KeyValuePair<int, Product> kvp in sorted_products)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}
Dictionary<int, Product> sorted_complex_product = c1.SortComplex();
Console.WriteLine("--Danh sách sản phẩm sau khi sắp xếp complex:--");
foreach (KeyValuePair<int, Product> kvp in sorted_complex_product)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

p5.Name ="Fanta";
p5.Price = 80;
p5.Quantity = 20;
bool ret = c1.UpdateProduct(p5);
Console.WriteLine("-- Sản phẩm sau khi chỉnh sửa: --");
c1.PrintAllProducts();

int id = 5;
ret = c1.RemoveProduct(id);
if(ret == false)
    Console.WriteLine($"Không tìm thấy mã {id} để xóa");
else
{
    Console.WriteLine($"Đã xóa thành công sản phẩm có {id} ");
    Console.WriteLine("--Sản phẩm sau khi xóa:--");
    c1.PrintAllProducts();
}

ret = c1.RemoveComplex(0, 7);
if (ret == false) 
    Console.WriteLine("Không có sản phẩm để xóa!");
else
{
    Console.WriteLine("Đã xóa thành công các sản phẩm có giá < 20");
    Console.WriteLine("--Sản phẩm sau khi xóa:--");
    c1.PrintAllProducts();
}

LinkedList<Category> categories = new LinkedList<Category>();
categories.AddLast(c1);

Category c2 = new Category();
c2.Id = 2;
c2.Name = "Bia các loại";

c2.AddProduct(new Product { Id = 6, Name = "Tiger", Quantity = 10, Price = 300 });
c2.AddProduct(new Product { Id = 7, Name = "Heineken", Quantity = 5, Price = 350 });
c2.AddProduct(new Product { Id = 8, Name = "333", Quantity = 8, Price = 250 });

categories.AddFirst(c2);
Console.WriteLine("---Danh sách toàn bộ sản phẩm theo danh mục---");
foreach (Category c in categories)
{
    Console.WriteLine(c);
    Console.WriteLine("Danh sách gồm có: ");
    c.PrintAllProducts();
    Console.WriteLine("---------------------");
}