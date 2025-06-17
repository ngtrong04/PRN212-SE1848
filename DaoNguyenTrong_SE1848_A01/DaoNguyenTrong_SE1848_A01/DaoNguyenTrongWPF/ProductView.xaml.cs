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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongWPF.ViewModels;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductViewModel ViewModel => DataContext as ProductViewModel;
        
        public ProductView()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ProductDialog(); // Cần tạo ProductDialog cho Add/Edit
            if (dialog.ShowDialog() == true)
            {
                var newProduct = dialog.Product;
                ViewModel.AddProduct(newProduct);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selectedProduct)
            {
                var dialog = new ProductDialog(selectedProduct); // Truyền sản phẩm đã chọn để sửa
                if (dialog.ShowDialog() == true)
                {
                    var updatedProduct = dialog.Product;
                    ViewModel.UpdateProduct(updatedProduct);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa.", "Sửa sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selectedProduct)
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{selectedProduct.ProductName}'?",
                                             "Xóa sản phẩm", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    ViewModel.DeleteProduct(selectedProduct.ProductID);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Xóa sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchBox.Text.Trim();
            ViewModel.SearchProducts(keyword);
        }
    }
}
