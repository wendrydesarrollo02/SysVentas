using APISysVentas.Aplicacion.Dominio.Entities;
using APISysVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace APISysVentas.Aplicacion.Services.Interfaz
{
    public interface IAPIInventarioPatridgeDbContext
    {
        DbSet<Users> Users { get; set; }
        //DbSet<Usuarios> Usuarios { get; set; }
        DbSet<productos> productos { get; set; }
    }
}
