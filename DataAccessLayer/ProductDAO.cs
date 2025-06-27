using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();
        public void GenerateSampleDataset()
        {
            products.Add(new Product() { Id = 1, Name = "CoCa", Quantity = 10, Price = 100.0 });
            products.Add(new Product() { Id = 2, Name = "Pepsi", Quantity = 20, Price = 200.0 });
            products.Add(new Product() { Id = 3, Name = "7UP", Quantity = 30, Price = 300.0 });
            products.Add(new Product() { Id = 4, Name = "Sting", Quantity = 40, Price = 400.0 });
            products.Add(new Product() { Id = 5, Name = "Sprite", Quantity = 50, Price = 500.0 });
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public bool SaveProduct(Product product)
        {
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old != null)
                return false;//mã sản phẩm này đã tồn tại, ko thêm mới được
            products.Add(product);
            return true;//thêm mới thành công
        }
        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProduct(Product product)
        {
            // Bước 1: tìm xem product muốn sửa có tồn tại hay không
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old == null)
                return false; // không tìm thấy sản phẩm để sửa
            old.Name = product.Name;
            old.Quantity = product.Quantity;
            old.Price = product.Price;
            return true;
        }

        public bool DeleteProduct(int id)
        {
            Product p = GetProduct(id);
            if (p != null)
            {
                products.Remove(p);
                return true;
            }
            return false;
        }

        public bool DeleteProduct(Product product)
        {
            if (product == null )
                return false;
            return DeleteProduct(product.Id);
        }

        
    }
}
