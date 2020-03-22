using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/subcategories/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<IQueryable<SubCategory>> Get()
        {
            return await _subCategoryService.FindAll();
        }

        /// <summary>
        /// Get the subcategories.  
        /// </summary>
        [HttpGet]
        [Route("getAll")]
        public List<SubCategoryDetails> GetAll()
        {
            return _subCategoryService.GetAll();
        }

        /// <summary>
        /// Get the subcategory by Id.
        /// </summary>
        /// <returns>
        /// Sub category model.
        /// </returns>
        [HttpGet]
        [Route("get/{idSubCategory}")]
        public async Task<SubCategory> GetById(Guid idSubCategory)
        {
            var query = await _subCategoryService.FindByCondition(x => x.Id == idSubCategory);
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Save the sub category
        /// <see cref="SubCategory"/>The subcategory model. 
        /// </summary>
        /// <param name="subcategory"></param>
        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Add([FromBody]SubCategory subcategory)
        {
            _subCategoryService.Create(subcategory);
            await _subCategoryService.SaveChage();
            return CreatedAtAction(nameof(GetById), new { idSubCategory = subcategory.Id }, subcategory);
        }

        /// <summary>
        /// Delete subcategory by Id.
        /// </summary>
        /// <returns>
        /// Sub category deleted
        /// </returns>
        [HttpDelete]
        [Route("delete/{idSubCategory}")]
        public async Task<SubCategory> DeleteByName(Guid idSubCategory)
        {
            return await _subCategoryService.DeleteById(idSubCategory);
        }

        /// <summary>
        /// Update the sub category.
        /// <see cref="SubCategory"/> the sub category model. 
        /// </summary>
        /// <param name="subcategory"></param>
        [HttpPut]
        [Route("update")]
        public async Task<SubCategory> Update([FromBody]SubCategory subcategory)
        {
            return await _subCategoryService.Modify(subcategory);
        }
    }
}