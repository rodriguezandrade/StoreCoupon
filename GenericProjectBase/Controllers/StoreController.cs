using System;
using System.Threading.Tasks;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/stores/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly ILoggerManager _loggerManager;
        public StoreController(IStoreService storeService, ILoggerManager loggerManeger )
        {
            _loggerManager = loggerManeger;
            _storeService = storeService;
        }

        /// <summary>
        /// Get the stores.  
        /// </summary>
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _storeService.GetAll();
                _loggerManager.LogInfo("Stores se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los stores: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetStores()
        {
            try
            {
                var query = await _storeService.GetStores();
                _loggerManager.LogInfo("Stores se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los stores: " + e);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get store by Id.
        /// </summary>
        /// <returns>
        /// Store model.
        /// </returns>
        [HttpGet]
        [Route("get/{idStore}")]
        public async Task<IActionResult> GetById(Guid idStore)
        {
            try
            {
                var query = await _storeService.GetById(idStore);
                _loggerManager.LogInfo("Store se obtuvo correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el store: " + e);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Save the store
        /// <see cref="StoreDto"/>The store model. 
        /// </summary>
        /// <param name="store"></param>
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Add([FromBody] StoreDto store)
        {
            try
            {
                _storeService.Save(store); 
                _loggerManager.LogInfo("Store guardado exitosamente");
                return CreatedAtAction(nameof(GetById), new { idStore = store.Id }, store);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el store: " + e);
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Delete store by Id.
        /// </summary>
        /// <returns>
        /// Store deleted.
        /// </returns>
        [HttpDelete]
        [Route("delete/{idStore}")]
        public async Task<IActionResult> DeleteById(Guid idStore)
        {
            try
            {
                var query = await _storeService.DeleteById(idStore);
                _loggerManager.LogInfo("El store fue eliminado correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el store: " + e);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update the store.
        /// <see cref="Store"/> the store model. 
        /// </summary>
        /// <param name="store"></param>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] StoreDto store)
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