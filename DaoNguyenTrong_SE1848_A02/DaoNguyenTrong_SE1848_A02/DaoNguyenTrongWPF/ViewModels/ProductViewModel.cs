using BusinessObjects.Models;
using Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        private readonly IProductRepository repo;
        public event PropertyChangedEventHandler PropertyChanged;

        public ProductViewModel()
        {
            repo = new ProductRepository();
            Load();
        }
        public void Load()
        {
            Products = new ObservableCollection<Product>(repo.GetAll());
            OnPropertyChanged(nameof(Products));
        }
        public void Add(Product p)
        {
            repo.Add(p);
            Products.Add(p);
        }
        public void Update(Product p)
        {
            repo.Update(p);
            Load();
        }
        public void Delete(int id)
        {
            repo.Delete(id);
            var prod = Products.FirstOrDefault(x => x.ProductId == id);
            if (prod != null) Products.Remove(prod);
        }
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}