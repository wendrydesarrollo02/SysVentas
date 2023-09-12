using APISysVentas.Aplicacion.Dominio.Dtos;
using APISysVentas.Aplicacion.Dominio.Entities;

namespace APISysVentas.Aplicacion.Data.Services.Interfaz
{
    public interface IProductosServices
    {
        Task<List<productos>> GetAll();
        Task<productos> GetById(int Id);
        Task<productos> GetByName(string names);
        Task<List<productos>> GetByCategoria(string categoria);
    }
}
