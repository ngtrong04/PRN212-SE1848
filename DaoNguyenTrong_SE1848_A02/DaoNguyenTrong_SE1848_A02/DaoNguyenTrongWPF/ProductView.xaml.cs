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
using Repositories;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        private ProductRepository _repo;
        public List<Product> Products { get; set; }

        public ProductView()
        {
            InitializeComponent();
            _repo = new ProductRepository();
            LoadProducts();
            DataContext = this;
        }

        private void LoadProducts()
        {
            Products = _repo.GetAll().ToList();
            ProductGrid.ItemsSource = Products;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ProductDialog();
            if (dialog.ShowDialog() == true)
            {
                _repo.Add(dialog.Product);
                LoadProducts();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var selected = ProductGrid.SelectedItem as Product;
            if (selected != null)
            {
                var dialog = new ProductDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    _repo.Update(dialog.Product);
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selected = ProductGrid.SelectedItem as Product;
            if (selected != null)
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _repo.Delete(selected.ProductId);
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchBox.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadProducts();
            }
            else
            {
                Products = _repo.Search(keyword).ToList();
                ProductGrid.ItemsSource = Products;
            }
        }
    }
}
