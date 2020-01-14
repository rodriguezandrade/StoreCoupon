using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace GenericProjectBase.Controllers
{
    [Route("api/categories/")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("getAll")]
        public async Task<IQueryable<Category>> Get()
        {
            return await _categoryService.GetAll();
        } 

        [Route("save")]
        [HttpPost]
        public Category Save([FromBody] Category category)
        {
            return _categoryService.Save(category);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<Category> DeleteByName([FromQuery] string name)
        {
            return await _categoryService.DeleteByName(name);
        }

        [Route("getById")]
        [HttpGet]
        public async Task<Category> GetById([FromQuery] Guid id)
        { 
            return await _categoryService.GetById(id);
        }
    }
}