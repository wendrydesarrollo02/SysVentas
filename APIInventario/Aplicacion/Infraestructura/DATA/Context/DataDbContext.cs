using APISysVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace APISysVentas.Aplicacion.Infraestructura.DATA.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) 
        {
            
        }

        public virtual DbSet<Users> Usuarios { get; set; }
    }
}
