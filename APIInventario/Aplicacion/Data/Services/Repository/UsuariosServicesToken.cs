using APISysVentas.Aplicacion.Data.Services.Interfaz;
using APISysVentas.Aplicacion.Dominio.Entities;
using APISysVentas.Aplicacion.Services.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace APISysVentas.Aplicacion.Data.Services.Repository
{
    public class UsuariosServicesToken : IUsuariosServicesToken
    {
        private readonly IAPIInventarioPatridgeDbContext _PatridgeDbContext;

        public UsuariosServicesToken(IAPIInventarioPatridgeDbContext aPIInventarioPatridgeDb)
        {
            _PatridgeDbContext = aPIInventarioPatridgeDb;
        }
        public async Task<List<Usuarios>> Get()
        {
            //var getUsuario = await _PatridgeDbContext.Usuarios.ToListAsync();
            return null; //getUsuario;
        }
    }
}
