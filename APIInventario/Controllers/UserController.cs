using APISysVentas.Aplicacion.Data.Services.Interfaz;
using APISysVentas.Aplicacion.Dominio.Entities;
using APISysVentas.Aplicacion.Services.Interfaz;
using APISysVentas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
//using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace APISysVentas.Controllers
{

    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {

        //public IConfiguration _configuration;
        ////public IUsuariosServicesToken _UsuariosServicesToken;
        //private readonly IAPIInventarioPatridgeDbContext _PatridgeDbContext;
        //public UserController(IConfiguration configuration, IAPIInventarioPatridgeDbContext aPIInventarioPatridge)
        //{
        //    _configuration = configuration;
        //    _PatridgeDbContext = aPIInventarioPatridge;
        //}

    //    [HttpPost]
    //    [Route("Token")]
    //    public async dynamic Token([FromBody] Object opdata)
    //    //{

    //    //    return nameof(Token);
    //    //    //try
    //    //    //{
    //    //    //    //var data = JsonConvert.DeserializeObject<dynamic>(opdata.ToString());
    //    //    //    //string user = data.usuario.ToString();
    //    //    //    //string password = data.password.ToString();

    //    //    //    ////Users usr = Users.DB().Where(x => x.Username == user && x.Password == password).FirstOrDefault();
    //    //    //    ////var usr = _UsuariosServicesToken.Get();
    //    //    //    //Usuarios usr = await _PatridgeDbContext.Usuarios.Where(x => x.Email == user && x.Contrasena == password).FirstOrDefaultAsync();

    //    //    //    //if (usr == null)
    //    //    //    //{
    //    //    //    //    return new
    //    //    //    //    {
    //    //    //    //        success = false,
    //    //    //    //        message = "Usuario o contraseña inválido!",
    //    //    //    //        result = ""
    //    //    //    //    };
    //    //    //    //}

    //    //    //   //var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
    //    //    //   // var claims = new[]
    //    //    //   // {
    //    //    //   //     //new Claim( JwtRegisteredClaimNames.Sub, jwt.Subject ),
    //    //    //   //     //new Claim( JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() ),
    //    //    //   //     //new Claim( JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString() ),
    //    //    //   //     //new Claim( "Email", usr.Email),
    //    //    //   //     //new Claim( "Contrasena", usr.Contrasena),
    //    //    //   // };


    //    //    //    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
    //    //    //    //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //    //    //    //DateTime expireDate = DateTime.Now.AddMinutes(5);
    //    //    //    //var token = new JwtSecurityToken(

    //    //    //        //jwt.Issuer,
    //    //    //        //jwt.Audience,
    //    //    //        //claims,
    //    //    //        //expires: expireDate,
    //    //    //        //signingCredentials: signIn
    //    //    //        );
    //    //    //    return new
    //    //    //    {
    //    //    //        Success = true,
    //    //    //        Message = "éxito!",
    //    //    //        Result = new
    //    //    //        {
    //    //    //            //Token = new JwtSecurityTokenHandler().WriteToken(token),
    //    //    //            //Expires = expireDate.ToString("dd/MM/yyyy h:mm:ss tt")
    //    //    //        }

    //    //    //    };

    //    //    //}
    //    //    //catch (Exception ex)
    //    //    //{
    //    //    //    return new
    //    //    //    {
    //    //    //        Success = false,
    //    //    //        Message = "Ocurrió un error al obtener el Token, por favor verifique los parámetros.",
    //    //    //        Result = ""

    //    //    //    };

    //    //    //}

    //    //}
    //}
    }

}