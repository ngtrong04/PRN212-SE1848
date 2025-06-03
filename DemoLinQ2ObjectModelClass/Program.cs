using DemoLinQ2ObjectModelClass;

ListProduct lp= new ListProduct();
lp.gen_products();

// câu 1: lọc ra các sản phẩm có giá từ a đến b
var result = lp.FilterProductsByPrice(100, 200);
Console.WriteLine("các sp có giá từ 100 đến 200:");
result.ForEach(p => Console.WriteLine(p));


// câu 2: sắp xếp sản phẩm theo đơn giá tăng dần
var result2 = lp.SortProductsByPriceAsc();
Console.WriteLine("Danh sách các sản phẩm sau khi sắp xếp giá tăng dần");
result2.ForEach(p => Console.WriteLine(p));

// câu 3: sắp xếp sản phẩm theo đơn giá giảm dần
var result3 = lp.SortProductsByPriceDesc();
Console.WriteLine("Danh sách sản phẩm đơn giá giảm dần: ");
result3.ForEach(p => Console.WriteLine(p));

// câu 4: tính tổng giá trị các sản phẩm trong kho hàng
Console.WriteLine("tổng giá trị kho hàng: " + lp.SumOfValue());

// câu 5: tìm chi tiết sản phẩm khi biết mã sp
Product p = lp.SearchProductsDetail(3);
if (p != null)
{
    Console.WriteLine("Chi tiết sản phẩm có mã 3: " + p);
}
else
{
    Console.WriteLine("Không tìm thấy sản phẩm có mã 3");
}

// câu 6: viết hàm lọc ra TOP N sản phẩm có giá trị lớn nhất
var result6 = lp.TopNSanPhamCoTriGiaMax(5);
Console.WriteLine("TOP 5 sản phẩm có giá trị lớn nhất:");
result6.ForEach(p => Console.WriteLine(p + " =>" + p.Quantity * p.Price));