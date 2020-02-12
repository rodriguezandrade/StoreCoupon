using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Models.Dtos;

namespace StoreCoupon.Controllers
{
    [Route("api/subcategories/")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        [Route("get")] 
        public async Task<IQueryable<SubCategoryDto>>GetAll()
        {
            return await _subCategoryService.GetAll();
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IQueryable<SubCategory>> Get()
        {
            return await _subCategoryService.FindAll();
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
        public async Task<ActionResult> Add([FromBody]SubCategory subCategory)
        {
            _subCategoryService.Create(subCategory);
            await _subCategoryService.SaveChage();
            return CreatedAtAction(nameof(GetById), new { idSubCategory = subCategory.Id }, subCategory);
        }

        [HttpDelete]
        [Route("delete/{Id}")]
        public async Task<SubCategory> DeleteById(Guid Id)
        {
            return await _subCategoryService.DeleteById(Id);
        }

        [HttpPut]
        [Route("update")]
        public async Task<SubCategory> Update([FromBody]SubCategory subCategory)
        {
            return await _subCategoryService.Modify(subCategory);
        }
    }
}