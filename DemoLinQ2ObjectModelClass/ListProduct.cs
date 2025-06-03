using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinQ2ObjectModelClass
{
    public class ListProduct
    { 
        List<Product> products;
        public ListProduct()
        {
            products = new List<Product>();
        }

        public void gen_products()
        {
            products.Add(new Product { Id = 1, Name = "P1", Quantity = 10, Price = 100 });
            products.Add(new Product { Id = 2, Name = "P2", Quantity = 20, Price = 203 });
            products.Add(new Product { Id = 3, Name = "P3", Quantity = 15, Price = 120 });
            products.Add(new Product { Id = 4, Name = "P4", Quantity = 5, Price = 250 });
            products.Add(new Product { Id = 5, Name = "P5", Quantity = 8, Price = 150 });
            products.Add(new Product { Id = 6, Name = "P6", Quantity = 10, Price = 50 });
            products.Add(new Product { Id = 7, Name = "P7", Quantity = 20, Price = 20 });
            products.Add(new Product { Id = 8, Name = "P8", Quantity = 15, Price = 30 });
            products.Add(new Product { Id = 9, Name = "P9", Quantity = 5, Price = 450 });
            products.Add(new Product { Id = 10, Name = "P10", Quantity = 8, Price = 390 });
        }

        public List<Product> FilterProductsByPrice(double minPrice, double maxPrice)
        {
            var result = from p in products
                         where p.Price >= minPrice && p.Price <= maxPrice
                         select p;
            return result.ToList();
        }
        
        public List<Product> FilterProductsByPrice2(double minPrice, double maxPrice)
        {
            return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }

        public List<Product> SortProductsByPriceAsc()
        {
            return products.OrderBy(p => p.Price).ToList();
        }
        public List<Product> SortProductsByPriceAsc2()
        {
            var result = from p in products
                         orderby p.Price 
                         select p;
            return result.ToList();
        }
        public List <Product> SortProductsByPriceDesc() {
            return products.OrderByDescending(p => p.Price).ToList();
        }

        public double SumOfValue()
        {
            return products.Sum(p => p.Price * p.Quantity);
        }

        public Product SearchProductsDetail(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> TopNSanPhamCoTriGiaMax(int n)
        {
            return products.OrderByDescending(p => p.Price * p.Quantity)
                           .Take(n)
                           .ToList();
        }
    }
}
