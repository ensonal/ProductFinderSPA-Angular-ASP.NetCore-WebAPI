using System;
using ProductFinder.DataAccess.Abstract;
using ProductFinder.Entities;

namespace ProductFinder.DataAccess.Concrete
{
	public class ProductRepository:IProductRepository
	{
       
        public Product CreateProduct(Product product)
        {
            using (var productDbContext = new ProductDbContext())
            {
                productDbContext.Product.Add(product);
                productDbContext.SaveChanges();
                return product;
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var productDbContext = new ProductDbContext())
            {
                return productDbContext.Product.ToList();

            }
        }

        public Product GetProductById(int Id)
        {
            using(var productDbContext = new ProductDbContext())
            {
                return productDbContext.Product.Find(Id);

            }
        }

        public void DeleteProduct(int Id)
        {
            using(var productDbContext = new ProductDbContext())
            {
                var deletedProduct = GetProductById(Id);
                productDbContext.Product.Remove(deletedProduct);
                productDbContext.SaveChanges();
            }
           
            
        }

        public Product UpdateProduct(Product product)
        {
            using (var productDbContext = new ProductDbContext())
            {
                productDbContext.Product.Update(product);
                productDbContext.SaveChanges();
                return product;
            }
        }
    }   
}

