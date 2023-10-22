using API_IBGE.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_IBGE.Services
{
    public class AuthorizationService
    {
        public string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
            new Claim("username",usuario.UserName),
            new Claim("id", usuario.Id),
            new Claim("LoginTimeStamp",DateTime.UtcNow.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("inpib!b324onr28r*)*$)*ójú15648cpyi"));

            var signingCreditials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(7),
                claims: claims,
                signingCredentials: signingCreditials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
