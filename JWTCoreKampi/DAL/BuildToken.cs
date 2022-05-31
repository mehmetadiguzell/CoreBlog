using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTCoreKampi.DAL
{
    public class BuildToken
    {
        public string CreateToken()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcore");
            SymmetricSecurityKey key = new(bytes);
            SigningCredentials signing = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new(
                issuer: "http://localhost",
                audience: "http://localhost",
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signing);
            JwtSecurityTokenHandler handler = new();
            return handler.WriteToken(token);
        }
    }
}
