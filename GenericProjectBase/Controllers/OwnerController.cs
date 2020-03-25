using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/owners/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;
        private readonly ILoggerManager _loggerManager;
        public OwnerController(IOwnerService ownerService, ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
            _ownerService = ownerService;
        }

        /// <summary>
        /// Get the owners.  
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _ownerService.Get();
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los owners: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Get owner by guid.
        ///s<see cref="Guid"/>Guid annotation. 
        /// </summary>
        /// <param name="id"> id owner</param>
        /// <returns>
        /// Owner model.
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = await _ownerService.GetById(id); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el owner: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save the owners
        /// <see cref="OwnerDto"/> the owner model. 
        /// </summary>
        /// <param name="owner"></param>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OwnerDto owner)
        {
            try
            {
                owner.Id = new Guid();
                _ownerService.Save(owner);
                return CreatedAtAction(nameof(GetById), new { idOwner = owner.Id }, owner);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el owner: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }

        }

        /// <summary>
        /// Delete owner by Id.
        /// </summary>
        /// <returns>
        /// Owner deleted.
        /// </returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var query = await _ownerService.DeleteById(id); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el owner: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update the owner.
        /// <see cref="OwnerDto"/> the owner model. 
        /// </summary>
        /// <param name="owner"></param>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OwnerDto owner)
        {
            try
            {
                var query = await _ownerService.Update(owner); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el owner: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}