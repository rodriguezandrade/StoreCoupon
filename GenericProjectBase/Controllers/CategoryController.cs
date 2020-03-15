using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Role = Repository.Repositories.Utils.Role;

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

        [Authorize(Roles = Role.Admin)]
        [Route("getAll")]
        public async Task<IQueryable<GeneralCategory>> Get()
        {
            return await _categoryService.GetAll();
        } 

        [Route("save")]
        [HttpPost]
        public GeneralCategory Save([FromBody] GeneralCategory category)
        {
            return _categoryService.Save(category);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<GeneralCategory> DeleteByName(Guid Id)
        {
            return await _categoryService.DeleteById(Id);
        }

        [Route("getById/{id}")]
        [HttpGet]
        public async Task<GeneralCategory> GetById(Guid id)
        { 
            return await _categoryService.GetById(id);
        }

        [HttpPut]
        [Route("update")]
        public async Task<GeneralCategory> Update([FromBody]GeneralCategory category)
        {
            return await _categoryService.Update(category);
        }
    }
}