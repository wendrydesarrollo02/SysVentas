using APISysVentas.Aplicacion.Dominio.Entities;
using APISysVentas.Aplicacion.Services.Interfaz;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APISysVentas.Aplicacion.Services.Repository
{
    public class TokenService : ITokenSevice
    {
        //Variable 
        private readonly SymmetricSecurityKey _SymetricSecurity;

        public TokenService(IConfiguration configuration)
        {
            _SymetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public string CreateToken(Users users)
        {
            var claims = new List<Claim>()
            {
             new Claim(JwtRegisteredClaimNames.NameId, users.Email!)
            };

            //Varibles 
            var credencialesToken = new SigningCredentials(_SymetricSecurity, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credencialesToken

                //$(MSBuildProjectName)
            };

            //Variables
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            //Retornar la cadena
            return tokenHandler.WriteToken(token);
        }
    }
}
