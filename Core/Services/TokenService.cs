
using Core.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Models;
using Repository.Models.Dtos.Account;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public interface ITokenService
    {
        string CreateAuthToken(UserRoleDto user);
    }

    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        private readonly IAccountService _accountService;
        public TokenService(IOptions<AppSettings> appSettings, IAccountService accountService)
        {
            _appSettings = appSettings.Value;
            _accountService = accountService;
        }

        // Authentication successful so generate jwt token 
        public string CreateAuthToken(UserRoleDto user)
        {
      
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var expireTime =_appSettings.ExpireTime;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(expireTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); 
        }
    }
}
