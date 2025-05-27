using System.Text;
using OOP2;
using OOP4_Reuse_OOP2;

Console.OutputEncoding = Encoding.UTF8;

FulltimeEmployee fe = new FulltimeEmployee();
fe.Id = 1;
fe.Name = "Nguyễn Văn A";   
fe.IdCard = "12345";
fe.Birthday = new DateTime(1952, 5, 1);
Console.WriteLine(fe);
Console.WriteLine("AGE: " + fe.Tuoi());

// hãy bổ sung thêm 1 extention method trả về có phải tháng này là tháng sinh nhật của employee hay không.

Console.WriteLine("Tháng này có phải là tháng sinh nhật của " + fe.Name + " không? " + fe.ThangSinhNhatCuaEmployee());