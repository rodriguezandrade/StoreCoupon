using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace StoreCoupon.Controllers
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

        [HttpGet]
        [Route("getCategories")]
        public async Task<IQueryable> GetCategories() {
            return await _categoryService.GetCategories();
        }

        [Route("save")]
        [HttpPost]
        public Category Save([FromBody] Category category)
        {
            return _categoryService.Save(category);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<Category> DeleteById([FromQuery] Guid Id)
        {
            return await _categoryService.DeleteById(Id);
        }

        [Route("getById")]
        [HttpGet]
        public async Task<Category> GetById([FromQuery] Guid id)
        { 
            return await _categoryService.GetById(id);
        }

        [Route("update")]
        [HttpPut]
        public async Task<Category> Update([FromBody]Category category){
            return await _categoryService.Update(category);
        }
    }
}