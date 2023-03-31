using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductFinder.Business.Abstract;
using ProductFinder.Business.Concrete;
using ProductFinder.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("{Id}")]
        public Product Get(int Id)
        {
            return _productService.GetProductById(Id);
        }

        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            return _productService.CreateProduct(product);
        }

        [HttpPut]
        public Product Put([FromBody] Product product)
        {
            return _productService.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            _productService.DeleteProduct(Id);
        }




        /*
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */
    }
}

