using APISysVentas.Models;

namespace APISysVentas.Aplicacion.Services.Interfaz
{
    public interface ITokenSevice
    {
        string CreateToken(Users users);
    }
}
