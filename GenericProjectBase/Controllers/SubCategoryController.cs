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
    [Route("api/subcategories/")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IQueryable<SubCategory>> Get()
        {
            return await _subCategoryService.FindAll();
        }

        [HttpGet]
        [Route("getAll")]
        public List<SubCategoryDto> GetAll()
        {
            return  _subCategoryService.GetAll();
        }

        [HttpGet]
        [Route("get/{idSubCategory}")]
        public async Task<SubCategory> GetById(Guid idSubCategory)
        {
            var query = await _subCategoryService.FindByCondition(x => x.Id == idSubCategory);
            return query.FirstOrDefault();
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Add([FromBody]SubCategory subcategory)
        {
            _subCategoryService.Create(subcategory);
            await _subCategoryService.SaveChage();
            return CreatedAtAction(nameof(GetById), new { idSubCategory = subcategory.Id }, subcategory);
        }

        [HttpDelete]
        [Route("delete/{idSubCategory}")]
        public async Task<SubCategory> DeleteByName(Guid idSubCategory)
        {
            return await _subCategoryService.DeleteById(idSubCategory);
        }

        [HttpPut]
        [Route("update")]
        public async Task<SubCategory> Update([FromBody]SubCategory subcategory)
        {
            return await _subCategoryService.Modify(subcategory);
        }

    }
}