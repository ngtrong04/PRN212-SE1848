using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for CategoryDialog.xaml
    /// </summary>
    public partial class CategoryDialog : Window
    {
        public Category Category { get; set; }
        public CategoryDialog()
        {
            InitializeComponent();
            Category = new Category();
            DataContext = Category;
            DisplayPicture();
        }

        public CategoryDialog(Category existingCategory)
        {
            InitializeComponent();
            Category = existingCategory;
            DataContext = Category;
            DisplayPicture();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        // Sự kiện khi bấm nút chọn ảnh
        private void ChoosePicture_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == true)
            {
                Category.Picture = File.ReadAllBytes(dlg.FileName);
                DisplayPicture();
            }
        }

        // Hàm hiển thị ảnh lên Image control
        private void DisplayPicture()
        {
            if (Category.Picture != null && Category.Picture.Length > 0)
            {
                using (var ms = new MemoryStream(Category.Picture))
                {
                    var img = new BitmapImage();
                    img.BeginInit();
                    img.CacheOption = BitmapCacheOption.OnLoad;
                    img.StreamSource = ms;
                    img.EndInit();
                    CategoryImage.Source = img;
                }
            }
            else
            {
                CategoryImage.Source = null;
            }
        }
    }
}
