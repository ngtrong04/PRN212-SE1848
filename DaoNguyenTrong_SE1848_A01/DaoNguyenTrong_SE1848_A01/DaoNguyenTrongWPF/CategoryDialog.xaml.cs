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
using DaoNguyenTrongLib.Models;

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
        }

        public CategoryDialog(Category existingCategory)
        {
            InitializeComponent();
            Category = existingCategory;
            DataContext = Category;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
