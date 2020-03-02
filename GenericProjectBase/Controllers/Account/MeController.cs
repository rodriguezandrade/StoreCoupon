
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos.Account;
using System;
using System.Net;
using System.Text;
using System.Web.Http;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace GenericProjectBase.Controllers.Account
{
    [Route("api/me/")]
    public class MeController : Controller
    {
        private readonly IAccountService _userService;
        private readonly ITokenService _tokenManagerService;

        public MeController(IAccountService userService, ITokenService tokenManagerService)
        {
            _userService = userService;
            _tokenManagerService = tokenManagerService;
        }

        [HttpPost]
        [Route("auth")]
        [AllowAnonymous]
        public ActionResult Authenticate(LoginRequest model)
        {
            var token = new UserRoleDto();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model == null)
            {
                return BadRequest(AppResources.InvalidCredentials);
            }

            var encData_byte = new byte[model.Password.Length];
            encData_byte = Encoding.UTF8.GetBytes(model.Password);
            var password = Convert.ToBase64String(encData_byte);

            var result = _userService.GetUserName(model.UserName, password);

            if (result == null)
            {
                return Ok();
            }

            if (result.UserName == null)
            {
                 return BadRequest(AppResources.InvalidCredentials);
            }

            token = _tokenManagerService.Authenticate(result);

            return Ok(token);
        }
    }
}