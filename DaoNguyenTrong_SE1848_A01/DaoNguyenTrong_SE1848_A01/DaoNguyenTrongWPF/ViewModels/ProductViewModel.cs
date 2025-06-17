using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Services;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly ProductService _productService;

        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }

        public ProductViewModel()
        {
            _productService = new ProductService(new DaoNguyenTrongLib.Repositories.ProductRepository());
            Products = new ObservableCollection<Product>(_productService.GetAllProducts());
        }

        public void AddProduct(Product product)
        {
            _productService.AddProduct(product);
            Products.Add(product);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            _productService.UpdateProduct(updatedProduct);
            var oldProduct = Products.FirstOrDefault(p => p.ProductID == updatedProduct.ProductID);
            if (oldProduct != null)
            {
                int index = Products.IndexOf(oldProduct);
                Products[index] = updatedProduct;
            }
        }

        public void DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            var product = Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
                Products.Remove(product);
        }

        public void SearchProducts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Products.Clear();
                foreach (var prod in _productService.GetAllProducts())
                    Products.Add(prod);
            }
            else
            {
                var filtered = _productService.SearchProducts(keyword);
                Products.Clear();
                foreach (var prod in filtered)
                    Products.Add(prod);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
