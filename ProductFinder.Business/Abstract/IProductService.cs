using System;
using ProductFinder.Entities;

namespace ProductFinder.Business.Abstract
{
	public interface IProductService
	{
		List<Product> GetAllProducts();

        Product GetProductById(int Id);

        Product CreateProduct(Product product);

        Product UpdateProduct(Product product);

        void DeleteProduct(int Id);


    }
}

