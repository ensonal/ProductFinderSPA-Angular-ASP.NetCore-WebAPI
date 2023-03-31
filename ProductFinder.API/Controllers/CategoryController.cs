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
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> Get()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet("{Id}")]
        public Category Get(int Id)
        {
            return _categoryService.GetCategoryById(Id);
        }

        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            return _categoryService.CreateCategory(category);
        }

        [HttpPut]
        public Category Put([FromBody] Category category)
        {
            return _categoryService.UpdateCategory(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            _categoryService.DeleteCategory(Id);
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

