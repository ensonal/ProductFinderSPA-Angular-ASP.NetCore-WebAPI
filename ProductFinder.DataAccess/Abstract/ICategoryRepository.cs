using System;
using System.Collections.Generic;
using ProductFinder.Entities;
namespace ProductFinder.DataAccess.Abstract
{
	public interface ICategoryRepository
	{
        List<Category> GetAllCategories();

        Category GetCategoryById(int Id);

        Category CreateCategory(Category Category);

        Category UpdateCategory(Category Category);

        void DeleteCategory(int Id);
    }
}

