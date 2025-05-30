using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }

        public Category()
        {
            Products = new Dictionary<int, Product>(); // khởi tạo Dictionary
        }
        public override string ToString()
        {
            return $"Id: {Id}\t Name: {Name}";
        }
        // khi quan ly moi doi tuong ta deu phai dap ung du tinh nang CRUD.
        public void AddProduct(Product p)
        {
            // kiểm tra Id của product chưa tồn tại thì thêm mới
            if (p == null)
            {
                return;  // dữ liệu đầu vào null
                 
            }
            if (Products.ContainsKey(p.Id))
            {
                return; // Id đã tồn tại không thêm
            }
            // thêm mới Product vào Dictionary
            Products.Add(p.Id, p);
        }
        // xuất toàn bộ sản phẩm:
        public void PrintAllProducts()
        {
            foreach (KeyValuePair<int, Product> kvp in Products) 
            {
                Product p = kvp.Value;
                Console.WriteLine(p);
            }
        }
        // lọc các sản phẩm có giá từ min tới max

        public Dictionary<int, Product> 
            FilterProductsByPrice(double min, double max)
        {
            return Products
                .Where(item => item.Value.Price >= min && item.Value.Price <= max)
                .ToDictionary<int, Product>();
        }
        // sắp xếp sản phẩm theo đơn giá tăng dần

        public Dictionary<int, Product> SortProductsByPrice()
        {
            return Products
                .OrderBy(item => item.Value.Price)
                .ToDictionary<int, Product>();
        }

        public Dictionary<int, Product> SortComplex()
        {
            return Products
                .OrderByDescending(item => item.Value.Quantity)
                .OrderBy(item => item.Value.Price)
                
                .ToDictionary<int, Product>();
        }
        public bool UpdateProduct(Product p)
        {
            if(p == null)
            {
                return false; // nhập null mà sao sửa
            }
            if(Products.ContainsKey(p.Id) == false) 
            { 
                return false; 
            }
            // cập nhật giá trị tại ô nhớ p.Id
            Products[p.Id] = p;
            return true; // cập nhật thành công
        }

        public bool RemoveProduct(int id)
        {
            if(Products.ContainsKey(id) == false)
                return false; // kh tìm thấy id để xóa
            Products.Remove(id);
            return true; // xóa thành công
        }

        // viết hàm cho phép xóa nhiều sản phẩm có số lượng từ a đến b
        public bool RemoveComplex(int min, int max) 
        {
            
            var productsToRemove = Products
                .Where(item => item.Value.Quantity >= min && item.Value.Quantity <= max)
                .Select(item => item.Key) // lấy ra các key (id) của sản phẩm
                .ToList(); // chuyển sang danh sách
            // xóa các sản phẩm này
            foreach (var id in productsToRemove)
            {
                Products.Remove(id);
            }
            return true; // xóa thành công
        }
    }
}
