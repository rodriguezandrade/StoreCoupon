
namespace Core.Services
{
    public interface ITokenService
    {
        string Create(string userName, string role);
    }

    public class TokenService : ITokenService
    {
        public string Create(string userName, string role)
        {
            //// appsetting for Token JWT
            //var secretKey = AppResources.JWT_SECRET_KEY;
            //var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            //var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            //var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            //var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            //var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //// create a claimsIdentity
            //var claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName), new Claim(ClaimTypes.Role, role) });
            //// create token to the user
            //var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            //var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
            //    audience: audienceToken,
            //    issuer: issuerToken,
            //    subject: claimsIdentity,
            //    notBefore: DateTime.UtcNow,
            //    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
            //    signingCredentials: signingCredentials);

            //var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            //return jwtTokenString;
        }
    }
}
