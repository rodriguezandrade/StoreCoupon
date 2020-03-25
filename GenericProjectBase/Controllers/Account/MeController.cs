
using Core.Exceptions;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos.Account;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace GenericProjectBase.Controllers.Account
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class MeController : ControllerBase
    {
        private readonly IAccountService _userService;
        private readonly ITokenService _tokenManagerService;

        public MeController(IAccountService userService, ITokenService tokenManagerService)
        {
            _userService = userService;
            _tokenManagerService = tokenManagerService;
        }

        /// <summary>
        /// CreateAuthToken & generate JWToken
        /// <see cref="LoginRequest"/>The login request. 
        /// </summary>
        /// <param name="loginRequest">The Request Data</param>
        [HttpPost()]
        [Route("auth")]
        [AllowAnonymous]
        public IActionResult Authenticate([System.Web.Http.FromBody]LoginRequest loginRequest)
        {
            var token = string.Empty;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if (loginRequest == null)
            { 
                throw new ApiException(AppResources.InvalidCredentials, HttpStatusCode.Unauthorized);
            }

            //var encData_byte = new byte[model.Password.Length];
            //encData_byte = Encoding.UTF8.GetBytes(model.Password);
            //var password = Convert.ToBase64String(encData_byte);

            var result = _userService.GetUserName(loginRequest.UserName, loginRequest.Password);

            if (result == null)
            {
                return Ok(result);
            }

            if (result.UserName == null)
            {
                throw new ApiException(AppResources.InvalidRequest, HttpStatusCode.BadRequest);
            }

            token = _tokenManagerService.CreateAuthToken(result);
            return Ok(token);
        }
    }
}