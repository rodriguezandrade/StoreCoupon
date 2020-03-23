﻿
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;
using System;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GenericProjectBase.Controllers
{
    [Route("api/stores-categories/")]
    public class Store_CategoryController : Controller 
    {
        private readonly IStore_CategoryService _storeService;
        private readonly ILoggerManager _loggerManager;
        public Store_CategoryController(IStore_CategoryService storeService, ILoggerManager loggerManeger)
        {
            _loggerManager = loggerManeger;
            _storeService = storeService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _storeService.GetAll();
                _loggerManager.LogInfo("StoresCategories se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los storescategories: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetStoresCategories()
        {
            try
            {
                var query = await _storeService.GetStoresCategories();
                _loggerManager.LogInfo("StoresCategories se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los storescategories: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("get/{idStore}")]
        public async Task<IActionResult> GetById(Guid idStore)
        {
            try
            {
                var query = await _storeService.GetById(idStore);
                _loggerManager.LogInfo("Store_Categories se obtuvo correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el store: " + e);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Add([FromBody] Store_CategoryDto store)
        {
            try
            {
                _storeService.Save(store);
                await _storeService.SaveChanges();
                _loggerManager.LogInfo("Store_Categories guardado exitosamente");
                return CreatedAtAction(nameof(GetById), new { idStore = store.Id }, store);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el store: " + e);
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("delete/{idStoreCategories}")]
        public async Task<IActionResult> DeleteById(Guid idStoreCategories)
        {
            try
            {
                var query = await _storeService.DeleteById(idStoreCategories);
                _loggerManager.LogInfo("El store fue eliminado correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el store: " + e);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Store_CategoryDto store)
        {
            try
            {
                var query = await _storeService.Update(store);
                _loggerManager.LogInfo("El store fue modificado exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el store: " + e);
                return StatusCode(500);
            }
        }

    }
}