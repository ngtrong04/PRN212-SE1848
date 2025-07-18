using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects.Models;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for ProductDialog.xaml
    /// </summary>
    public partial class ProductDialog : Window
    {
        public Product Product { get; set; }

        public ProductDialog()
        {
            InitializeComponent();
            Product = new Product();
            DataContext = Product;
        }

        public ProductDialog(Product product)
        {
            InitializeComponent();
            // Tạo bản sao để edit, tránh ảnh hưởng trực tiếp đến dữ liệu gốc nếu cần
            Product = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            };
            DataContext = Product;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            // Có thể kiểm tra dữ liệu hợp lệ ở đây nếu muốn
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
