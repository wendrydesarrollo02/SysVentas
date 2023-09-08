using APISysVentas.Aplicacion.Aauthentication;
using APISysVentas.Aplicacion.Configuration;
using APISysVentas.Aplicacion.Dominio.Entities;
using APISysVentas.Aplicacion.Services.Interfaz;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APISysVentas.Aplicacion.Data.Context
{
    public class APIInventarioPatridgeDbContext : IdentityDbContext<ApplicationUsers>, IAPIInventarioPatridgeDbContext
    {
        public APIInventarioPatridgeDbContext(DbContextOptions<APIInventarioPatridgeDbContext> options)
            : base(options) 
        {
            
        }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasesEntityConfiguration<>).Assembly);

            //OnModelCreatingPartial(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
