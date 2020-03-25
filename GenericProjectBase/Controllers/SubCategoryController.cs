using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Logger.Interface;
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
        private readonly ILoggerManager _loggerManager;
        public SubCategoryController(ISubCategoryService subCategoryService, ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
            _subCategoryService = subCategoryService;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _subCategoryService.GetAll();
                _loggerManager.LogInfo("SubCategorys se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los subcategorys: " + e);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get the subcategories.  
        /// </summary>
        [HttpGet]
        [Route("getAll")]
        public async Task<IQueryable<SubCategoryDetails>> GetAll()
        {
            return await _subCategoryService.GetAll();
        }

        /// <summary>
        /// Get the subcategory by Id.
        /// </summary>
        /// <returns>
        /// Sub category model.
        /// </returns>
        [HttpGet]
        [Route("get/{idSubCategory}")]
        public async Task<IActionResult> GetById(Guid idSubCategory)
        {
            try
            {
                var query = await _subCategoryService.GetById(idSubCategory);
                _loggerManager.LogInfo("SubCategory se obtuvo correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el subcategory: " + e);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Save the sub category
        /// <see cref="SubCategory"/>The subcategory model. 
        /// </summary>
        /// <param name="subcategory"></param>
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Add([FromBody] SubCategoryDto subcategory)
        {
            try
            {
                _subCategoryService.Save(subcategory);
                await _subCategoryService.SaveChanges();
                _loggerManager.LogInfo("SubCategory guardado exitosamente");
                return CreatedAtAction(nameof(GetById), new { idSubCategory = subcategory.Id }, subcategory);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el subcategory: " + e);
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Delete subcategory by Id.
        /// </summary>
        /// <returns>
        /// Sub category deleted
        /// </returns>
        [HttpDelete]
        [Route("delete/{idSubCategory}")]
        public async Task<IActionResult> DeleteById(Guid idSubCategory)
        {
            try
            {
                var query = await _subCategoryService.DeleteById(idSubCategory);
                _loggerManager.LogInfo("El subcategory fue eliminado correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el subcategory: " + e);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update the sub category.
        /// <see cref="SubCategory"/> the sub category model. 
        /// </summary>
        /// <param name="subcategory"></param>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] SubCategoryDto subcategory)
        {
            try
            {
                var query = await _subCategoryService.Update(subcategory);
                _loggerManager.LogInfo("El subcategory fue modificado exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el subcategory: " + e);
                return StatusCode(500);
            }
        }
    }
}