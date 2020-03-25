using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;
using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]/")]
    public class StoreCategoryController : Controller 
    {
        private readonly IStoreCategoryService _storeService;
        private readonly ILoggerManager _loggerManager;
        public StoreCategoryController(IStoreCategoryService storeService, ILoggerManager loggerManeger)
        {
            _loggerManager = loggerManeger;
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _storeService.Get(); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los storescategories: {e}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> GetStoresCategoriesDetails()
        {
            try
            {
                var query = await _storeService.GetDetails(); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los storescategories: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = await _storeService.GetById(id);
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener el store: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StoreCategoryDto store)
        {
            try
            {
                _storeService.Save(store); 
                return CreatedAtAction(nameof(GetById), new { idStore = store.Id }, store);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error cuando se intentaba guardar el store: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(Guid idStoreCategories)
        {
            try
            {
                var query = await _storeService.DeleteById(idStoreCategories); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se eliminaba el store: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StoreCategoryDto store)
        {
            try
            {
                var query = await _storeService.Update(store); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se modificaba el store: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

    }
}