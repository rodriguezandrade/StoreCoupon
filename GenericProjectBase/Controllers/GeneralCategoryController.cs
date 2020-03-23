using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Fluent;
using Repository.Models;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/categories/")]
    public class GeneralCategoryController : Controller
    {
        private readonly IGeneralCategoryService _categoryService;
        private readonly ILoggerManager _loggerManager;

        public GeneralCategoryController(IGeneralCategoryService categoryService, ILoggerManager loggerManager)
        {
            _categoryService = categoryService;
            _loggerManager = loggerManager;
        }

        [Route("getAll")]
        public async Task<IActionResult> Get()
        {
            try 
            {
                var query = await _categoryService.GetAll();
                _loggerManager.LogInfo("Se obtuvieron todas las Categorias Generales correctamente");
                return Ok(query);
            }
            catch(Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se obtenian las Categorias Generales: "+ e);
                return StatusCode(500);
            }
            
        } 

        [Route("save")]
        [HttpPost]
        public IActionResult Save([FromBody] GeneralCategoryDto category)
        {   
            try
            {
                _categoryService.Save(category);
                _loggerManager.LogInfo("Se guardo la Categoria General correctamente");
                return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
            }
            catch(Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se guardaba la Categoria General: "+e);
                return StatusCode(500);
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteByName(Guid Id)
        {
            try 
            {
                var query = await _categoryService.DeleteById(Id);
                _loggerManager.LogInfo("La Categoria General fue eliminada correctamente");
                return Ok(query);
            }
            catch(Exception e) 
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba la Categoria General: " + e);
                return StatusCode(500);
            }
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            try 
            {
                var query = await _categoryService.GetById(id);
                _loggerManager.LogInfo("Se obtuvo la Categoria General exitosamente");
                return Ok(query);
            }
            catch (Exception e) 
            {
                _loggerManager.LogError("Ocurrio un error mientras se obtenia la Categoria General: " + e);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody]GeneralCategoryDto category)
        {
            try
            {
                var query = await _categoryService.Update(category);
                _loggerManager.LogInfo("Se modifico la Categoria General exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba la Categoria General: " + e);
                return StatusCode(500);
            }
        }
    }
}