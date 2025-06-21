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
    }
}
