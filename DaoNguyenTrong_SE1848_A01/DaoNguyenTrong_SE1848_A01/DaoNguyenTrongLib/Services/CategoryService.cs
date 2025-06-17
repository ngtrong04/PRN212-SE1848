using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Repositories;

namespace DaoNguyenTrongLib.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories() => _categoryRepository.GetAll();

        public Category GetCategoryById(int id) => _categoryRepository.GetById(id);

        public void AddCategory(Category category) => _categoryRepository.Add(category);

        public void UpdateCategory(Category category) => _categoryRepository.Update(category);

        public void DeleteCategory(int id) => _categoryRepository.Delete(id);

        public IEnumerable<Category> SearchCategories(string keyword) => _categoryRepository.Search(keyword);
    }
}
