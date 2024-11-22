using Microsoft.IdentityModel.Tokens;
using Shop.Application.Contract.IServices.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.EndPoint.API.Securities
{
    public class TokenHandler : ITokenHandler
    {
        //private const string RoleClaimType = "Roles";
        private const string UserIdClaimType = "UserId";

        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;

        public TokenHandler()
        {
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public string GenerateToken(string userId, params string[] roles)
        {
            var claims = new List<Claim>
            {
                new Claim(UserIdClaimType,userId),
            };

            roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            //claims.AddRange(roles.Select(r => new Claim(RoleClaimType, r)).ToList());

            var securityToken = CreateSecurityToken(claims);

            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        private SecurityToken CreateSecurityToken(List<Claim> claims)
        {
            var sign = new SigningCredentials(GenerateKey(), SecurityAlgorithms.HmacSha256Signature);


            var description = new SecurityTokenDescriptor
            {
                Audience = "localhost",
                Issuer = "localhost",
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = sign,
                Subject = new ClaimsIdentity(claims)
            };

            return jwtSecurityTokenHandler.CreateToken(description);
        }

        private static SecurityKey GenerateKey()
        {
            var key = "vjhgjhgbk32ییسشjkjloij6576hiuhiujhgh87y";
            byte[] bytes = Encoding.UTF8.GetBytes(key);
            return new SymmetricSecurityKey(bytes);
        }

        public List<Claim> ValidateToken(string token)
        {
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                IssuerSigningKey = GenerateKey()
            };
            return jwtSecurityTokenHandler.ValidateToken(token, parameters, out SecurityToken _).Claims.ToList();

        }
    }
}
