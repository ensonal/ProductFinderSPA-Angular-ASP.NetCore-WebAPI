using System;
using ProductFinder.Business.Abstract;
using ProductFinder.DataAccess.Abstract;
using ProductFinder.DataAccess.Concrete;
using ProductFinder.Entities;

namespace ProductFinder.Business.Concrete
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public Product CreateProduct(Product product)   
        {
            return _productRepository.CreateProduct(product);
        }

        public void DeleteProduct(int Id)
        {
            _productRepository.DeleteProduct(Id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int Id)
        {
            if (Id > 0) {
                return _productRepository.GetProductById(Id);
            }
            else {
                throw new Exception("Id cannot be less than 1");
            }
            
        }

        public Product UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }
}

