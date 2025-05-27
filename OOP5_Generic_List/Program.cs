// sử dụng generic list để quản lí nhân sự với đầy đủ tính năng CRUD (Create, Read, Update, Delete)
// Create: tạo mới dữ liệu
// Read: xem lọc tìm kiếm sắp xếp thống kê
// Update: sửa dữ liệu
// Delete: xóa dữ liệu

// câu 1 tạo 5 nhân viên trong đó 3 nhân viên chính thức và 2 nhân viên partime lưu vào generic list

using System.Text;
using OOP2;

Console.OutputEncoding = Encoding.UTF8;
List<Employee> employees = new List<Employee>();
FulltimeEmployee fe1 = new FulltimeEmployee()
{
    Id = 1,
    Name = "Nguyễn Văn A",
    IdCard = "123",
    Birthday = new DateTime(1990, 1, 1)
};
employees.Add(fe1);

FulltimeEmployee fe2 = new FulltimeEmployee()
{
    Id = 2,
    Name = "Nguyễn Văn B",
    IdCard = "456",
    Birthday = new DateTime(1992, 12, 1)
};
employees.Add(fe2);

FulltimeEmployee fe3 = new FulltimeEmployee()
{
    Id = 3,
    Name = "Nguyễn Văn C",
    IdCard = "789",
    Birthday = new DateTime(1998, 1, 25)
};
employees.Add(fe3);

ParttimeEmployee pe1 = new ParttimeEmployee() 
{
    Id = 4,
    Name = "Nguyễn Văn D",
    IdCard = "101",
    Birthday = new DateTime(1995, 3, 15),
    WorkingHours = 20
};
employees.Add(pe1);

ParttimeEmployee pe2 = new ParttimeEmployee()
{
    Id = 5,
    Name = "Nguyễn Văn E",
    IdCard = "102",
    Birthday = new DateTime(1996, 4, 20),
    WorkingHours = 25
};
employees.Add(pe2);
// câu 2: R -> xuất toàn bộ nhân sự 
Console.WriteLine("Câu 2: Xuất toàn bộ nhân sự: ");
// cách 1:
employees.ForEach(emp => Console.WriteLine(emp));                         //lambda expression (=>)

// Câu 3: R -> lọc ra các nhân sự là chính thức
// cách 1: 
List<FulltimeEmployee> fe_list = employees.OfType<FulltimeEmployee>().ToList();
Console.WriteLine("Câu 3: Lọc ra các nhân sự là chính thức");
foreach (FulltimeEmployee fe in fe_list)
{
    Console.WriteLine(fe);
}
// câu 4: Tính tổng tiền lương phải trả cho nhân viên chính thức và thời vụ và tổng lương cho cả 2.
double fe_sum_salary = fe_list.Sum(fe => fe.calSalary());
Console.WriteLine("Câu 4: Tổng tiền lương phải trả cho nhân viên chính thức: ");
Console.WriteLine(fe_sum_salary);
double pe_sum_salary = employees.OfType<ParttimeEmployee>().Sum(pe => pe.calSalary());
Console.WriteLine("Câu 5: Tổng tiền lương phải trả cho nhân viên thời vụ: ");
Console.WriteLine(pe_sum_salary);
// Bài tập: Bổ sung thêm xóa, sửa nhân viên

// Câu 6: Sửa thông tin nhân viên
Console.WriteLine("Câu 6: Sửa thông tin nhân viên");
Console.WriteLine("Nhập ID nhân viên cần sửa: ");
int idToUpdate = int.Parse(Console.ReadLine()!);
Employee? employeeToUpdate = employees.FirstOrDefault(emp => emp.Id == idToUpdate);
if (employeeToUpdate != null)
{
    Console.WriteLine("Nhập tên mới: ");
    employeeToUpdate.Name = Console.ReadLine();
    Console.WriteLine("Nhập ID Card mới: ");
    employeeToUpdate.IdCard = Console.ReadLine();
    Console.WriteLine("Nhập ngày sinh mới (dd/MM/yyyy): ");
    employeeToUpdate.Birthday = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);
    Console.WriteLine("Thông tin nhân viên sau khi sửa: ");
    Console.WriteLine(employeeToUpdate);
}
else
{
    Console.WriteLine("Không tìm thấy nhân viên với ID đã nhập.");
}

// Câu 7: Xóa nhân viên
Console.WriteLine("Câu 7: Xóa nhân viên");
Console.WriteLine("Nhập ID nhân viên cần xóa: ");
int idToDelete = int.Parse(Console.ReadLine()!);
Employee? employeeToDelete = employees.FirstOrDefault(emp => emp.Id == idToDelete);
if (employeeToDelete != null)
{
    employees.Remove(employeeToDelete);
    Console.WriteLine("Nhân viên đã được xóa.");
    Console.WriteLine("Danh sách nhân sự còn lại sau khi xóa: ");
    employees.ForEach(emp => Console.WriteLine(emp));
}
else
{
    Console.WriteLine("Không tìm thấy nhân viên với ID đã nhập.");
}

