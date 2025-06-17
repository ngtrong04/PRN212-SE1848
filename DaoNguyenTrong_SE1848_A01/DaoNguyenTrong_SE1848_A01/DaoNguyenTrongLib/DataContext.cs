using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;

namespace DaoNguyenTrongLib
{
    /// <summary>
    /// Singleton DataContext chứa tất cả các danh sách thực thể (in-memory List<T>)
    /// </summary>
    
    public class DataContext
    {
        private static DataContext _instance;
        private static readonly object _lock = new object();

        // Danh sách các thực thể (in-memory)
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Category> Categories { get; set; }

        // Constructor private để đảm bảo Singleton
        private DataContext()
        {
            Customers = new List<Customer>();
            Products = new List<Product>();
            Orders = new List<Order>();
            OrderDetails = new List<OrderDetail>();
            Employees = new List<Employee>();
            Categories = new List<Category>();

            // (Tuỳ chọn) Thêm dữ liệu mẫu ở đây nếu cần
            SeedSampleData();
        }

        // Thuộc tính Instance để lấy ra DataContext duy nhất
        public static DataContext Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DataContext();
                    return _instance;
                }
            }
        }

        // (Tuỳ chọn) Hàm seed dữ liệu mẫu
        private void SeedSampleData()
        {
            Customers.Add(new Customer
            {
                CustomerID = 1,
                CompanyName = "Lucy Co.",
                ContactName = "Lucy Nguyen",
                ContactTitle = "Manager",
                Address = "123 Main St",
                Phone = "0123456789"
            });

            Customers.Add(new Customer
            {
                CustomerID = 2,
                CompanyName = "CocaCola Co.",
                ContactName = "Đào Nguyên Trọng",
                ContactTitle = "Manager",
                Address = "123 Gia Lai",
                Phone = "0944242035"
            });

            Customers.Add(new Customer
            {
                CustomerID = 3,
                CompanyName = "Pepsi Co.",
                ContactName = "Đào Nguyên John",
                ContactTitle = "Staff",
                Address = "456 Gia Lai",
                Phone = "0944242036"
            });

            Categories.Add(new Category
            {
                CategoryID = 1,
                CategoryName = "Electronics",
                Description = "Electronic devices"
            });

            Categories.Add(new Category
            {
                CategoryID = 2,
                CategoryName = "Ngước ngọt có ga",
                Description = "Uống siêu ngon"
            });

            Products.Add(new Product
            {
                ProductID = 1,
                ProductName = "Laptop",
                CategoryID = 1,
                UnitPrice = 1200,
                UnitsInStock = 10
            });

            Products.Add(new Product
            {
                ProductID = 2,
                ProductName = "Pepsi Không Calo",
                CategoryID = 2,
                UnitPrice = 1200,
                UnitsInStock = 15
            });

            Employees.Add(new Employee
            {
                EmployeeID = 1,
                Name = "John Smith",
                UserName = "john",
                Password = "123",
                JobTitle = "Sales"
            });

            Employees.Add(new Employee
            {
                EmployeeID = 2,
                Name = "John Wick",
                UserName = "john123",
                Password = "456",
                JobTitle = "Sales"
            });

            Orders.Add(new Order
            {
                OrderID = 1,
                CustomerID = 1,
                EmployeeID = 2,
                OrderDate = DateTime.Now
            });

            Orders.Add(new Order
            {
                OrderID = 2,
                CustomerID = 2,
                EmployeeID = 1,
                OrderDate = DateTime.Now
            });

            OrderDetails.Add(new OrderDetail
            {
                OrderID = 1,
                ProductID = 1,
                UnitPrice = 1200,
                Quantity = 2,
                Discount = 0
            });

            OrderDetails.Add(new OrderDetail
            {
                OrderID = 2,
                ProductID = 2,
                UnitPrice = 1400,
                Quantity = 10,
                Discount = 0
            });
        
    }
    }
}
