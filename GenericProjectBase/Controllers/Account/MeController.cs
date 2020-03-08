
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
    [Route("api/[controller]/")]
    public class MeController : ControllerBase
    {
        private readonly IAccountService _userService;
        private readonly ITokenService _tokenManagerService;

        public MeController(IAccountService userService, ITokenService tokenManagerService)
        {
            _userService = userService;
            _tokenManagerService = tokenManagerService;
        }

        [HttpPost()]
        [Route("auth")]
        [AllowAnonymous]
        public IActionResult Authenticate([System.Web.Http.FromBody]LoginRequest model)
        {
            var token = string.Empty;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if (model == null)
            { 
                throw new ApiException(AppResources.InvalidCredentials, HttpStatusCode.Unauthorized);
            }

            //var encData_byte = new byte[model.Password.Length];
            //encData_byte = Encoding.UTF8.GetBytes(model.Password);
            //var password = Convert.ToBase64String(encData_byte);

            var result = _userService.GetUserName(model.UserName, model.Password);

            if (result == null)
            {
                return Ok(result);
            }

            if (result.UserName == null)
            {
                //return BadRequest(AppResources.InvalidCredentials);
                throw new ApiException(AppResources.InvalidRequest, HttpStatusCode.BadRequest);
            }

            token = _tokenManagerService.Authenticate(result);

            return Ok(token);
        }
    }
}