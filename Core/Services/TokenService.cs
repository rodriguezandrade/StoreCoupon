using Core.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Models;
using Repository.Models.Dtos.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ServiceStack.Redis;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace Core.Services
{
    public interface ITokenService
    {
        string CreateAuthToken(UserRoleDto user);
        Task<string> RefreshToken(string refreshToken);
    }

    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        private readonly IAccountService _accountService;
        private readonly IDistributedCache _distributedCache;
        private readonly IRedisCacheClient _redisCacheClient;
        public TokenService(
            IOptions<AppSettings> appSettings,
            IAccountService accountService,
            IDistributedCache distributedCache,
            IRedisCacheClient redisCacheClient)
        {
            _appSettings = appSettings.Value;
            _accountService = accountService;
            _distributedCache = distributedCache;
            _redisCacheClient = redisCacheClient;
        }

        // Authentication successful so generate jwt token 
        public string CreateAuthToken(UserRoleDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var expireTime = _appSettings.ExpireTime;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Issuer = _appSettings.ValidIssuer,
                Audience = _appSettings.ValidAudience,
                Expires = DateTime.UtcNow.AddMinutes(expireTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> RefreshToken(string refreshToken)
        {
            //var redisManager = new RedisManagerPool("localhost:6379");
            //var redis = redisManager.GetClient();
            //redis.As<UserRoleDto>();
            var dto = new UserRoleDto
            {
                Id = 1,
                Address = "Barrio el calvario"
            };
            //redis.Store(dto);
          
            var tokenCacheKey = refreshToken.ToLower();
            List<string> tokenList;
            var encodeRefreshToken = await _distributedCache.GetAsync(tokenCacheKey);
            if (encodeRefreshToken != null)
            {
                tokenCacheKey = Encoding.UTF8.GetString(encodeRefreshToken);
                //tokenList = JsonConvert.DeserializeObject<List<string>>(tokenCacheKey);
            }
            else
            {
                encodeRefreshToken = Encoding.UTF8.GetBytes(tokenCacheKey);
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                bool isAdded = await _redisCacheClient.Db0.AddAsync("UserRole", dto, options.AbsoluteExpiration.Value);
                await _distributedCache.SetAsync(tokenCacheKey, encodeRefreshToken, options);
            }

            return tokenCacheKey;
        }
    }
}
