using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;
using System;
using System.Threading.Tasks;
using Role = Repository.Repositories.Utils.Role;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/storecategories/")]
    [ApiVersion("2")]
    [ApiVersion("1")]
    [Route("api/storecategories/")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILoggerManager _loggerManager;

        public CategoryController(ILoggerManager loggerManager, ICategoryService categoryservice)
        {
            _loggerManager = loggerManager;
            _categoryService = categoryservice;
        }
        
         /// <summary>
        ///<remarks>Get the categories.</remarks>
        /// </summary>
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _categoryService.GetAll();
                _loggerManager.LogInfo("Category se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los categorys: " + e);
                return StatusCode(500);
            }
        }

       /// <see cref="id"/> the category model. 
        /// <summary>
        /// Get category by guid.
        /// </summary>
        /// <returns>
        /// Category model.
        /// </returns>
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = await _categoryService.GetById(id);
                _loggerManager.LogInfo("Owner se obtuvo correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el category Id: " +id + e);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Save the categories
        /// <see cref="CategoryStoreDto"/> the sub category model. 
        /// </summary>
        /// <param name="category"></param>
        //[Authorize(Roles = Role.Admin)]
        [Route("save")]
        [MapToApiVersion("2")] 
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryStoreDto category)
        {
            try
            {
                _categoryService.Save(category);
                await _categoryService.SaveChanges();
                _loggerManager.LogInfo("Owner guardado exitosamente");
                return CreatedAtAction(nameof(GetById), new { idCategory = category.Id }, category);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el category: " + e);
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Delete Category by Id.
        /// </summary>
        /// <returns>
        /// Category deleted.
        /// </returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var query = await _categoryService.DeleteById(id);
                _loggerManager.LogInfo("El category fue eliminado correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el category: " + e);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update the category.
        /// <see cref="CategoryStoreDto"/> the category model. 
        /// </summary>
        /// <param name="category"></param>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] CategoryStoreDto category)
        {
            try
            {
                var query = await _categoryService.Update(category);
                _loggerManager.LogInfo("El category fue modificado exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el category: " + e);
                return StatusCode(500);
            }
        }

    }
}