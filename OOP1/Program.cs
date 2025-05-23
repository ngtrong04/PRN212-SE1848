using OOP1;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Category c1 = new Category();
c1.Id = 1;
c1.Name = "Nước mắm";
c1.PrintInfor();

// giả sử ta đổi giá trị trong ô nhớ đó
c1.Name = "Nước mắm Phú Quốc";
Console.WriteLine("Sau khi đổi tên:");
c1.PrintInfor();

Console.WriteLine("================EMPLOYEE=====================");
Employee e1 = new Employee();
e1.Id = 1;
e1.IdCard = "001";
e1.Name = "Tèo";  // gọi setter property của Name
e1.Email = "teo@gmail.com";
e1.Phone = "0123456789";
e1.PrintInfor();


Employee e2 = new Employee()
{
    Id = 2,
    IdCard = "002",
    Name = "Tí",
    Email = "Ti@hmail.com",
    Phone = "0987654321"
};
Console.WriteLine("===============EMPLOYEE2======================");
e2.PrintInfor();

Console.WriteLine("===============EMPLOYEE4======================");

//tạo employee 4 
Employee e4 = new Employee(4, "004", "Tủn", "tun@gamil.com", "0394294934");
e4.PrintInfor();
Console.WriteLine(e4);  // tự gọi hàm ToString

Console.WriteLine("================CUSTOMER 1=====================");
Customer cus1 = new Customer()
{
    Id = "CUS1",
    Name = "Nguyễn Văn A",
    Email = "aaa@gmail.com",
    Phone = "0123456789",
    Address = "Hà Nội"
};

cus1.PrintInfor();
cus1.Address = "Hà Nội - Việt Nam";
Console.WriteLine("Sau khi đổi địa chỉ:");
cus1.PrintInfor();