using Core.Exceptions;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos.Account;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Threading.Tasks;
using Store.Coupon.Web;

namespace StoreCouponWeb.Controllers.Account
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
        /// CreateAuthToken
        /// <see cref="LoginRequest"/>The login request. 
        /// </summary>
        /// <param name="loginRequest">The Request Data</param>
        [HttpPost()]
        [Route("auth")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody]LoginRequest loginRequest)
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
                throw new ApiException(AppResources.InvalidCredentials, HttpStatusCode.Unauthorized);
            }

            token = _tokenManagerService.CreateAuthToken(result);
            return Ok(token);
        }

        /// <summary>
        /// Refresh AuthToken 
        /// </summary>
        /// <param name="refreshToken">token to refresh</param>
        [HttpPost()]
        [Route("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshAsync([FromQuery]string refreshToken)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refreshToken == null)
            {
                throw new ApiException(AppResources.InvalidCredentials, HttpStatusCode.Unauthorized);
            }

            //var encData_byte = new byte[model.Password.Length];
            //encData_byte = Encoding.UTF8.GetBytes(model.Password);
            //var password = Convert.ToBase64String(encData_byte);

            //var result = _userService.GetUserName(loginRequest.UserName, loginRequest.Password);

            //if (result == null)
            //{
            //    throw new ApiException(AppResources.InvalidCredentials, HttpStatusCode.Unauthorized);
            //}

              refreshToken = await  _tokenManagerService.RefreshToken(refreshToken);
            return Ok(refreshToken);
        }
    }
}