using APISysVentas.Aplicacion.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace APISysVentas.Aplicacion.Services.Interfaz
{
    public interface IAPIInventarioPatridgeDbContext
    {
        DbSet<Users> Users { get; set; }
    }
}
