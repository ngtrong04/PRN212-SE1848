using BusinessObjects.Models;
using Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CategoryDisplay> Categories { get; set; }
        public CategoryDisplay SelectedCategory { get; set; }
        private readonly ICategoryRepository repo;
        public event PropertyChangedEventHandler PropertyChanged;

        public CategoryViewModel()
        {
            repo = new CategoryRepository();
            Load();
        }
        public void Load()
        {
            Categories = new ObservableCollection<CategoryDisplay>(
                repo.GetAll().Select(c => new CategoryDisplay
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    Picture = c.Picture
                })
            );
            OnPropertyChanged(nameof(Categories));
        }

        public void Add(Category cat)
        {
            repo.Add(cat);
            Load();
        }
        public void Update(Category cat)
        {
            repo.Update(cat);
            Load();
        }
        public void Delete(int id)
        {
            repo.Delete(id);
            Load();
        }
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}