using System;
using ProductFinder.Entities;

namespace ProductFinder.Business.Abstract
{
	public interface ICategoryService
	{
        List<Category> GetAllCategories();

        Category GetCategoryById(int Id);

        Category CreateCategory(Category category);

        Category UpdateCategory(Category category);

        void DeleteCategory(int Id);

    }
}

