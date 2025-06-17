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
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {

        private CategoryViewModel ViewModel => DataContext as CategoryViewModel;
        public CategoryView()
        {
            InitializeComponent();
            DataContext = new CategoryViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CategoryDialog(); // Cần tạo CategoryDialog cho Add
            if (dialog.ShowDialog() == true)
            {
                var newCategory = dialog.Category;
                ViewModel.AddCategory(newCategory);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryGrid.SelectedItem is Category selectedCategory)
            {
                var dialog = new CategoryDialog(selectedCategory); // Truyền category đã chọn để sửa
                if (dialog.ShowDialog() == true)
                {
                    var updatedCategory = dialog.Category;
                    ViewModel.UpdateCategory(updatedCategory);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại hàng để sửa.", "Sửa loại hàng", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryGrid.SelectedItem is Category selectedCategory)
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại hàng '{selectedCategory.CategoryName}'?",
                                             "Xóa loại hàng", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    ViewModel.DeleteCategory(selectedCategory.CategoryID);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại hàng để xóa.", "Xóa loại hàng", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchBox.Text.Trim();
            ViewModel.SearchCategories(keyword);
        }
    }
}
