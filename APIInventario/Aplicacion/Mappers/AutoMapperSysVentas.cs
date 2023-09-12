using APISysVentas.Aplicacion.Dominio.Dtos;
using APISysVentas.Models;
using AutoMapper;

namespace APISysVentas.Aplicacion.Mappers
{
    public class AutoMapperSysVentas : Profile
    {
        public AutoMapperSysVentas()
        {
            #region MAPPER USER
            CreateMap<UsersRegisterDto, Users>();
            CreateMap<UsersLoginDto, Users>();
            CreateMap<Users, UsersListDto>();
            #endregion
        }
    }
}
