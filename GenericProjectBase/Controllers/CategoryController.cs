using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;
using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Role = Repository.Repositories.Utils.Role;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]/")]
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

        /// <see cref="Guid"/> the category model. 
        /// <summary>
        /// Get category by guid.
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
                _loggerManager.LogError("Ocurrio un error al obtener el category Id: " +id + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save the categories
        /// <see cref="CategoryStoreDto"/> the sub category model. 
        /// </summary>
        /// <param name="category"></param>
        //[Authorize(Roles = Role.Admin)]
        [MapToApiVersion("2")] 
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryStoreDto category)
        {
            try
            {
                _categoryService.Save(category);
                return CreatedAtAction(nameof(GetById), new { idCategory = category.Id }, category);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el category: " + e);
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
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el category: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update the category.
        /// <see cref="CategoryStoreDto"/> the category model. 
        /// </summary>
        /// <param name="category"></param>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryStoreDto category)
        {
            try
            { 
                return Ok(await _categoryService.Update(category));
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el category: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}