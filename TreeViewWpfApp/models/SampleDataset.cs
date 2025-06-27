using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewWpfApp.models
{
    public class SampleDataset
    {
        public static Dictionary<int, Category> GenerateDataset ()
        {
            Dictionary<int, Category> categories = new Dictionary<int, Category>();
            Category c1 = new Category { Id = 1, Name = "Nước ngọt" };
            Category c2 = new Category { Id = 2, Name = "Bia rượu" };
            Category c3 = new Category { Id = 3, Name = "Thức ăn nhanh" };
            categories.Add(c1.Id, c1);
            categories.Add(c2.Id, c2);
            categories.Add(c3.Id, c3);
            // cac sản phẩm của nước ngọt
            Product p1 = new Product { Id = 1, Name = "Coca Cola", Quantity = 100, Price = 10.0 };
            Product p2 = new Product { Id = 2, Name = "Pepsi", Quantity = 200, Price = 12.0 };
            Product p3 = new Product { Id = 3, Name = "7UP", Quantity = 150, Price = 11.0 };
            Product p4 = new Product { Id = 4, Name = "Sting", Quantity = 50, Price = 20.0 };
            Product p5 = new Product { Id = 5, Name = "RedBull", Quantity = 60, Price = 22.0 };
            //các sản phẩm của bia rượu
            Product p6 = new Product { Id = 6, Name = "SaiGonBeer", Quantity = 30, Price = 15.0 };
            Product p7 = new Product { Id = 7, Name = "Tiger", Quantity = 40, Price = 18.0 };
            Product p8 = new Product { Id = 8, Name = "Heniken", Quantity = 70, Price = 8.0 };
            Product p9 = new Product { Id = 9, Name = "333", Quantity = 80, Price = 10.0 };
            Product p10 = new Product { Id = 10, Name = "Tiger Silver", Quantity = 90, Price = 12.0 };
            // các sản phẩm của thức ăn nhanh
            Product p11 = new Product { Id = 11, Name = "Cà phê", Quantity = 120, Price = 5.0 };
            Product p12 = new Product { Id = 12, Name = "Trà sữa", Quantity = 130, Price = 6.0 };
            Product p13 = new Product { Id = 13, Name = "Nước ép", Quantity = 110, Price = 7.0 };
            Product p14 = new Product { Id = 14, Name = "Bánh mì", Quantity = 140, Price = 4.0 };
            Product p15 = new Product { Id = 15, Name = "Snack", Quantity = 160, Price = 9.0 };
            //thêm các sản phẩm vào danh mục nước ngọt
            c1.Products.Add(p1.Id, p1);
            c1.Products.Add(p2.Id, p2);
            c1.Products.Add(p3.Id, p3);
            c1.Products.Add(p4.Id, p4);
            c1.Products.Add(p5.Id, p5);
            //thêm các sản phẩm vào danh mục bia rượu
            c2.Products.Add(p6.Id, p6);
            c2.Products.Add(p7.Id, p7);
            c2.Products.Add(p8.Id, p8);
            c2.Products.Add(p9.Id, p9);
            c2.Products.Add(p10.Id, p10);
            //thêm các sản phẩm vào danh mục thức ăn nhanh
            c3.Products.Add(p11.Id, p11);
            c3.Products.Add(p12.Id, p12);
            c3.Products.Add(p13.Id, p13);
            c3.Products.Add(p14.Id, p14);
            c3.Products.Add(p15.Id, p15);

            return categories;
        }
    }
}
