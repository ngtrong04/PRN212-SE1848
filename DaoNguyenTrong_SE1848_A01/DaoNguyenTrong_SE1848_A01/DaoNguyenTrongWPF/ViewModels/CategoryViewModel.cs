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
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private readonly CategoryService _categoryService;

        public ObservableCollection<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }

        public CategoryViewModel()
        {
            _categoryService = new CategoryService(new DaoNguyenTrongLib.Repositories.CategoryRepository());
            Categories = new ObservableCollection<Category>(_categoryService.GetAllCategories());
        }

        public void AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
            Categories.Add(category);
        }

        public void UpdateCategory(Category updatedCategory)
        {
            _categoryService.UpdateCategory(updatedCategory);
            var oldCat = Categories.FirstOrDefault(c => c.CategoryID == updatedCategory.CategoryID);
            if (oldCat != null)
            {
                int index = Categories.IndexOf(oldCat);
                Categories[index] = updatedCategory;
            }
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            var cat = Categories.FirstOrDefault(c => c.CategoryID == categoryId);
            if (cat != null)
                Categories.Remove(cat);
        }

        public void SearchCategories(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Categories.Clear();
                foreach (var cat in _categoryService.GetAllCategories())
                    Categories.Add(cat);
            }
            else
            {
                var filtered = _categoryService.SearchCategories(keyword);
                Categories.Clear();
                foreach (var cat in filtered)
                    Categories.Add(cat);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
