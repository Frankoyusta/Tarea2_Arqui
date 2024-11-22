using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Tarea2_ArquiSistemas.Src.Services.Interfaces;

namespace Tarea2_ArquiSistemas.Src.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    config["AppSettings:TokenKey"] ?? throw new InvalidOperationException("Token key not found")
                )
            );
        }

        public string CreateToken(string email)
        {   
            Console.WriteLine("Haciendo el token en el servicio");
            var claims = new List<Claim> { new(JwtRegisteredClaimNames.Email, email), };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
             Console.WriteLine("Haciendo el token en el servicio");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMonths(2),
                SigningCredentials = creds
            };
            Console.WriteLine("Haciendo el token en el servicio");
            var tokenHandler = new JwtSecurityTokenHandler();
            Console.WriteLine("Haciendo el token en el servicio");
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}