using APISysVentas.Aplicacion.Dominio.Dtos;
using APISysVentas.Aplicacion.Dominio.Entities;

namespace APISysVentas.Aplicacion.Data.Services.Interfaz
{
    public interface IProductosServices
    {
        Task<List<productos>> GetAll();
    }
}
