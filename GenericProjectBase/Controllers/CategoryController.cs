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
    [Route("api/v{version:apiVersion}/categories/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        ///<remarks>Get the categories.</remarks>
        /// </summary>
        [Route("getAll")]
        [HttpPost]
        public async Task<IQueryable<GeneralCategory>> Get()
        {
            return await _categoryService.GetAll();
        }

        /// <summary>
        /// Save the categories
        /// <see cref="GeneralCategory"/> the sub category model. 
        /// </summary>
        /// <param name="category"></param>
        //[Authorize(Roles = Role.Admin)]
        [Route("save")]
        [HttpPost]
        [MapToApiVersion("2")] 
        public GeneralCategory Save([FromBody] GeneralCategory category)
        {
            return _categoryService.Save(category);
        }

        /// <summary>
        /// Delete Category by Id.
        /// </summary>
        /// <returns>
        /// Category deleted.
        /// </returns>
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<GeneralCategory> DeleteByName(Guid Id)
        {
            return await _categoryService.DeleteById(Id);
        }

        /// <summary>
        /// Get category by guid.
        /// </summary>
        /// <returns>
        /// Category model.
        /// </returns>
        [Route("getById/{id}")]
        [HttpGet]
        public async Task<GeneralCategory> GetById(Guid id)
        {
            return await _categoryService.GetById(id);
        }

        /// <summary>
        /// Update the category.
        /// <see cref="GeneralCategory"/> the category model. 
        /// </summary>
        /// <param name="category"></param>
        [HttpPut]
        [Route("update")]
        public async Task<GeneralCategory> Update([FromBody]GeneralCategory category)
        {
            return await _categoryService.Update(category);
        }
    }
}