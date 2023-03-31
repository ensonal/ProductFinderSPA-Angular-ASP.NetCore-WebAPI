using System;
using ProductFinder.Entities;

namespace ProductFinder.DataAccess.Abstract
{
	public interface IProductRepository
	{
		List<Product> GetAllProducts();

		Product GetProductById(int Id);

		Product CreateProduct(Product product);

		Product UpdateProduct(Product product);

		void DeleteProduct(int Id);
	}
}

