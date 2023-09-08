using APISysVentas.Aplicacion.Dominio.Entities;

namespace APISysVentas.Aplicacion.Services.Interfaz
{
    public interface ITokenSevice
    {
        string CreateToken(Users users);
    }
}
