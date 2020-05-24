using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos.Account;
using Store.Coupon.Web;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/users/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILoggerManager _loggerManager;
        public UserController(IUserService userService, ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
            _userService = userService;
        }

        /// <summary>
        /// Get the users.  
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _userService.Get();
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los users: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }


        /// <summary>
        /// Get user by guid.
        ///s<see cref="Guid"/>Guid annotation. 
        /// </summary>
        /// <param name="id"> id user</param>
        /// <returns>
        /// UserDetail model.
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = await _userService.GetById(id); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener el user: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save the owners
        /// <see cref="UserDto"/> the user model. 
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDto user)
        {
            try
            {
                //user.Id = Guid.NewGuid();
                _userService.Save(user);
                return CreatedAtAction(nameof(GetById), new { version = HttpContext.GetRequestedApiVersion().ToString(), id = user.Id }, user);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error cuando se intentaba guardar el user: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }

        }

        /// <summary>
        /// Delete user by Id.
        /// </summary>
        /// <returns>
        /// UserDetail deleted.
        /// </returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var query = await _userService.DeleteById(id); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se eliminaba el user: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update the user.
        /// <see cref="UserDto"/> the user model. 
        /// </summary>
        /// <param name="user"></param>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto user)
        {
            try
            {
                var query = await _userService.Update(user); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se modificaba el user: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}