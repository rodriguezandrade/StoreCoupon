using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;
using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Store.Coupon.Web;
using Role = Repository.Repositories.Utils.Role;

namespace StoreCouponWeb.Controllers
{
    [Route("api/v{version:apiVersion}/categories/")]
    [ApiVersion("2")]
    [ApiVersion("1")] 
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
       private readonly ILoggerManager _loggerManager;

        public CategoryController(ILoggerManager loggerManager, ICategoryService categoryservice)
        {
            _loggerManager = loggerManager;
            _categoryService = categoryservice;
        }

        ///<remarks>Get the categories.</remarks>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            { 
                return Ok(await _categoryService.Get());
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los categorys: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <see cref="Guid"/> the storeCategory model. 
        /// <summary>
        /// Get storeCategory by guid.
        /// </summary>
        /// <returns>
        /// Category model.
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            { 
                return Ok(await _categoryService.GetById(id));
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el storeCategory Id: " +id + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save the categories
        /// <see cref="StoreCategoryDto"/> the sub storeCategory model. 
        /// </summary>
        /// <param name="storeCategory"></param>
        //[Authorize(Roles = Role.Admin)]
        [MapToApiVersion("1")] 
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StoreCategoryDto storeCategory)
        {
            try 
            {
                storeCategory.Id =  Guid.NewGuid();
                _categoryService.Save(storeCategory);
                return CreatedAtAction(nameof(GetById), new { version = HttpContext.GetRequestedApiVersion().ToString(), id = storeCategory.Id }, storeCategory);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el storeCategory: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            } 
        }

        /// <summary>
        /// Delete Category by Id.
        /// </summary>
        /// <returns>
        /// Category deleted.
        /// </returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            { 
                return Ok(await _categoryService.DeleteById(id));
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el storeCategory: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update the storeCategory.
        /// <see cref="StoreCategoryDto"/> the storeCategory model. 
        /// </summary>
        /// <param name="storeCategory"></param>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StoreCategoryDto storeCategory)
        {
            try
            { 
                return Ok(await _categoryService.Update(storeCategory));
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el storeCategory: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}