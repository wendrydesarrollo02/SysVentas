using APISysVentas.Aplicacion.Dominio.Entities;

namespace APISysVentas.Aplicacion.Aauthentication.Interfaz
{
    public interface IAuthenticationServices
    {
        Task<Users> Registrar(Users users, string password);
        Task<Users> LoginUser(string email, string password);
        Task<bool> ExisteUser(string email);
    }
}
