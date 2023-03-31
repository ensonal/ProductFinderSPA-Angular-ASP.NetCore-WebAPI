using System;
using ProductFinder.Business.Abstract;
using ProductFinder.DataAccess.Abstract;
using ProductFinder.DataAccess.Concrete;
using ProductFinder.Entities;

namespace ProductFinder.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }

        public Category CreateCategory(Category category)
        {
            return _categoryRepository.CreateCategory(category);
        }

        public void DeleteCategory(int Id)
        {
            _categoryRepository.DeleteCategory(Id);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int Id)
        {
            if (Id > 0)
            {
                return _categoryRepository.GetCategoryById(Id);
            }
            else
            {
                throw new Exception("Id cannot be less than 1");
            }
        }

        public Category UpdateCategory(Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }
    }
}

