using System;
using System.Threading.Tasks;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/owners/")]
    public class OwnerController : Controller
    {

        private readonly IOwnerService _ownerService;
        private readonly ILoggerManager _loggerManager;
        public OwnerController(IOwnerService ownerService, ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
            _ownerService = ownerService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _ownerService.GetAll();
                _loggerManager.LogInfo("Owners se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los owners: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("get/{idOwner}")]
        public async Task<IActionResult> GetById(Guid idOwner)
        {
            try
            {
                var query = await _ownerService.GetById(idOwner);
                _loggerManager.LogInfo("Owner se obtuvo correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el owner: " + e);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Add([FromBody] OwnerDto owner)
        {
            try
            {
                _ownerService.Save(owner);
                await _ownerService.SaveChanges();
                _loggerManager.LogInfo("Owner guardado exitosamente");
                return CreatedAtAction(nameof(GetById), new { idOwner = owner.Id }, owner);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el owner: " + e);
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("delete/{idOwner}")]
        public async Task<IActionResult> DeleteById(Guid idOwner)
        {
            try
            {
                var query = await _ownerService.DeleteById(idOwner);
                _loggerManager.LogInfo("El owner fue eliminado correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el owner: " + e);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] OwnerDto owner)
        {
            try
            {
                var query = await _ownerService.Update(owner);
                _loggerManager.LogInfo("El owner fue modificado exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el owner: " + e);
                return StatusCode(500);
            }
        }

    }
}