
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace GenericProjectBase.Controllers.Account
{
    [Route("api/me")]
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
        [Route("")]
        [AllowAnonymous]
        public ActionResult Authenticate(LoginRequest model)
        {
            var token = string.Empty;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
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
                //return BadRequest(AppResources.InvalidCredentials);
            }

            token = _tokenManagerService.Create(result.UserName, result.Role);

            return Ok(token);
        }
    }
}