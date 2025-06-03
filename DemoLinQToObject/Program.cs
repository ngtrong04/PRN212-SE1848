using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int[] arr = { 100, 243, 341, 497, 501, 600, 701, 857, 931, 112 };

// câu 1: dùng linq để lọc ra các số chẵn
// cách method syntax
var result = arr.Where(x => x % 2 == 0);
//cách query syntax
var result2 = from x in arr
              where x % 2 == 0
              select x;
Console.WriteLine("Các số chẵn: ");
result2.ToList().ForEach(x => Console.Write(x + "\t"));

// câu 2: sắp xếp thoe thứ tự tăng dần

var result3 = arr.OrderBy(x => x);
var result4 = from x in arr
              orderby x 
              select x;
Console.WriteLine("danh sách sau khi sắp xếp tăng dần");
foreach (var item in result4)
{
    Console.Write(item + "\t");
}

//câu 3: sắp xếp theo thứ tự giảm dần
var result5 = arr.OrderByDescending(x => x);
var result6 = from x in arr
              orderby x descending
              select x;
Console.WriteLine("\ndanh sách sau khi sắp xếp giảm dần");
foreach (var item in result6)
{
    Console.Write(item + "\t");
}

// câu 4: đếm số lượng các số lẻ

int dem = arr.Where(x => x % 2 != 0).Count();