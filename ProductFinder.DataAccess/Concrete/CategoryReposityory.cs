using System;
using System.Collections.Generic;
using ProductFinder.DataAccess.Abstract;
using ProductFinder.Entities;
namespace ProductFinder.DataAccess.Concrete
{
	public class CategoryReposityory : ICategoryRepository
	{
        public Category CreateCategory(Category category)
        {
            using (var categoryDbContext = new CategoryDbContext())
            {
                categoryDbContext.Categories.Add(category);
                categoryDbContext.SaveChanges();
                return category;
            }
        }

       
        public Category GetCategoryById(int Id)
        {
            using (var categoryDbContext = new CategoryDbContext())
            {
                return categoryDbContext.Categories.Find(Id);

            }
        }

        public void DeleteCategory(int Id)
        {
            using (var categoryDbContext = new CategoryDbContext())
            {
                var deletedCategory = GetCategoryById(Id);
                categoryDbContext.Categories.Remove(deletedCategory);
                categoryDbContext.SaveChanges();
            }


        }

        public Category UpdateCategory(Category category)
        {
            using (var categoryDbContext = new CategoryDbContext())
            {
                categoryDbContext.Categories.Update(category);
                categoryDbContext.SaveChanges();
                return category;
            }
        }

        public List<Category> GetAllCategories()
        {
            using (var categoryDbContext = new CategoryDbContext())
            {
                return categoryDbContext.Categories.ToList();

            }
        }
    }
}

