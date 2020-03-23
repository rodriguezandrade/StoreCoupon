using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;
using System;
using System.Threading.Tasks;

namespace GenericProjectBase.Controllers
{
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

        [HttpGet]
        [Route("get/{idCategory}")]
        public async Task<IActionResult> GetById(Guid idCategory)
        {
            try
            {
                var query = await _categoryService.GetById(idCategory);
                _loggerManager.LogInfo("Owner se obtuvo correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el category: " + e);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("save")]
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

        [HttpDelete]
        [Route("delete/{idCategory}")]
        public async Task<IActionResult> DeleteById(Guid idCategory)
        {
            try
            {
                var query = await _categoryService.DeleteById(idCategory);
                _loggerManager.LogInfo("El category fue eliminado correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el category: " + e);
                return StatusCode(500);
            }
        }

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