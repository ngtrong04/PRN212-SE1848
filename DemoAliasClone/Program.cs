using System.Text;
using DemoAliasClone;

Console.OutputEncoding = Encoding.UTF8;
Customer c1 = new Customer();
c1.Id = 1;
c1.Name = "Nguyễn Văn A";

Customer c2 = new Customer();
c2.Id = 2;
c2.Name = "Nguyễn Văn B";

c1 = c2;
// c1 và c2 đều tham chiếu đến cùng một đối tượng Customer
// chứ không phải c1 = c2
// => lúc này xảy ra 2 tình huống:
//1. ô nhớ alpha mà c1 đang quan lý lúc nãy bị trống
// không còn đối tượng nào tham gia quản lý nữa
// => hệ điều hành sẽ tự động giải phóng ô nhớ alpha này .
//2. ô nhớ beta mà c2 đang quản lý sẽ có 2 đối tượng quản lý c2 ban đầu và bây h có thêm c1
// Trường hớp 1 ô nhớ từ 2 đói tượng trở lên tham gia quản lý nó được gọi là Alias
// bất kỳ 1 đồi tượng nào đổi giá trị tại ô nhớ beta --> thì các đối tượng còn lại đều bị ảnh hưởng
c1.Name = "Hồ Đồ";
// thì lúc này c2 cũng bị đổi tên thành Hồ Đồ
Console.WriteLine("tên của c2:" + c2.Name);

Customer c3 = new Customer();
Customer c4 = c3;
c3 = c1;
//không thu hồi c3 vì c3 vẫn đang có đối tượng c4 quản lý.


Product p1 = new Product { Id = 1, Name = "P1", Quantity = 10, Price = 20};
Product p2 = new Product { Id = 2, Name = "P2", Quantity = 5,  Price = 30};

p1 = p2;  // p1 trỏ đến vùng nhớ p2 quản lý 
Console.WriteLine("----Thông tin của p1----");
Console.WriteLine(p1);
Console.WriteLine("----Thông tin của p2----");
Console.WriteLine(p2);
// p1 và p2 đều tham chiếu đến cùng một đối tượng Product p2 (p1 biến mất do không còn ai quản lý nó nữa.)

p2.Name = "Thuốc tiên";
p2.Quantity = 100;
p2.Price = 1000;

Console.WriteLine("thông tin của p1:");
Console.WriteLine(p1);                   // => p2 đổi thì p1 cũng đổi theo

Product p3 = new Product { Id = 3, Name = "P3", Quantity = 15, Price = 50 };
Product p4 = new Product { Id = 4, Name = "P4", Quantity = 20, Price = 60 };

Product p5 = p3.Clone();  // sao chép đối tượng p3 sang p5
//hđh sao chép toàn booj dữ liệu trong ô nhớ mà p4 đang quản lý qua 1 ô nhớ mới và giao cho p5 quản lý 
//p3 và p5 là 2 ô nhớ khác nhau hoàn toàm nhưng có giá trị giống nhau
// ==> p5 đổi thì p3 không đổi và ngược lại.

