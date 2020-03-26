using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Models.Dtos;
using Store.Coupon.Web;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]/")]
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
        public async Task<IActionResult> Get()
        {
            try
            { 
                return Ok(await _subCategoryService.GetDetails());
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los subcategorys: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Get the subcategories.  
        /// </summary>
        [HttpGet]
        [Route("details")]
        public async Task<IQueryable<SubCategoryDto>> GetSubCategoryDetails()
        {
            return await _subCategoryService.GetDetails();
        }

        /// <summary>
        /// Get the subcategory by Id.
        /// </summary>
        /// <returns>
        /// Sub category model.
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            { 
                return Ok(await _subCategoryService.GetById(id));
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener el subcategory: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save the sub category
        /// <see cref="SubCategory"/>The subcategory model. 
        /// </summary>
        /// <param name="subcategory"></param>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SubCategoryDto subcategory)
        {
            try
            {
                _subCategoryService.Save(subcategory);
                // ReSharper disable once Mvc.ActionNotResolved
                return CreatedAtAction(nameof(GetById), new { idSubCategory = subcategory.Id }, subcategory);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error cuando se intentaba guardar el subcategory: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }

        }

        /// <summary>
        /// Delete subcategory by Id.
        /// </summary>
        /// <returns>
        /// Sub category deleted
        /// </returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            { 
                return Ok(await _subCategoryService.DeleteById(id));
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se eliminaba el subcategory: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update the sub category.
        /// <see cref="SubCategory"/> the sub category model. 
        /// </summary>
        /// <param name="subcategory"></param>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SubCategoryDto subcategory)
        {
            try
            { 
                return Ok(await _subCategoryService.Update(subcategory));
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se modificaba el subcategory: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}