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
using BusinessObjects.Models;
using DaoNguyenTrongWPF.ViewModels;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        private CategoryViewModel VM => DataContext as CategoryViewModel;

        public CategoryView()
        {
            InitializeComponent();
            DataContext = new CategoryViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CategoryDialog();
            if (dlg.ShowDialog() == true)
            {
                VM.Add(dlg.Category);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryGrid.SelectedItem is ViewModels.CategoryDisplay selected)
            {
                var category = new BusinessObjects.Models.Category
                {
                    CategoryId = selected.CategoryId,
                    CategoryName = selected.CategoryName,
                    Description = selected.Description,
                    Picture = selected.Picture
                };
                var dlg = new CategoryDialog(category);
                if (dlg.ShowDialog() == true)
                {
                    VM.Update(dlg.Category);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một danh mục để sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryGrid.SelectedItem is ViewModels.CategoryDisplay selected)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    VM.Delete(selected.CategoryId);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một danh mục để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchBox.Text.Trim();
            VM.Load();
            // Nếu có hàm VM.Search(keyword) thì gọi hàm Search
        }
    }
}
