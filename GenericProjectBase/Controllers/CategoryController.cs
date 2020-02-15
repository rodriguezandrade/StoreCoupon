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

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<Category> DeleteByName(Guid Id)
        {
            return await _categoryService.DeleteById(Id);
        }

        [Route("getById/{id}")]
        [HttpGet]
        public async Task<Category> GetById(Guid id)
        { 
            return await _categoryService.GetById(id);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Category> Update([FromBody]Category category)
        {
            return await _categoryService.Update(category);
        }
    }
}