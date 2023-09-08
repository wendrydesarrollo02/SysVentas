using APISysVentas.Aplicacion.Aauthentication.Interfaz;
using APISysVentas.Aplicacion.Dominio.Dtos;
using APISysVentas.Aplicacion.Dominio.Entities;
using APISysVentas.Aplicacion.Services.Interfaz;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISysVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _AuthenticationService;

        private readonly ITokenSevice _TokenSevice;

        private readonly IMapper _Mapper;

        public AuthenticationController(IAuthenticationServices authenticationService, ITokenSevice tokenSevice,
            IMapper mapper)
        {
            this._AuthenticationService = authenticationService;
            this._TokenSevice = tokenSevice;
            this._Mapper = mapper;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UsersRegisterDto usersRegisterDto)
        {
            usersRegisterDto.Email = usersRegisterDto.Email.ToLower(); //PARA PASAR EL USUARIO A MINUSCULA

            if (await _AuthenticationService.ExisteUser(usersRegisterDto.Email))
                return BadRequest("ESTE CORREO ELECTRONICO YA ESTA REGISTRADO" +
                    "POR FAVOR UTILIZAR OTRO CORREO ELECTRONICO PARA REGISTRARSE");

            var userNuevo = _Mapper.Map<Users>(usersRegisterDto);
            var userCreated = await _AuthenticationService.Registrar(userNuevo, usersRegisterDto.PasswordUser);
            var userCreatedDto = _Mapper.Map<UsersListDto>(userCreated);

            return Ok(userCreatedDto);

        }

        [HttpPost("{Login}")]
        public async Task<IActionResult> Login(UsersLoginDto usersLoginDto)
        {
            var userFromRepo = await _AuthenticationService.LoginUser(usersLoginDto.Email, usersLoginDto.PasswordUser);
            if (userFromRepo == null)
                return Unauthorized();

            var userMap = _Mapper.Map<UsersListDto>(usersLoginDto);
            var tokenSer = _TokenSevice.CreateToken(userFromRepo);

            return Ok(new
            {
                userMap = userMap,
                tokeSer = tokenSer,

            });

        }
    }
}
