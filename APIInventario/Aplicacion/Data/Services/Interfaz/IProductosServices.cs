using APISysVentas.Aplicacion.Dominio.Dtos;

namespace APISysVentas.Aplicacion.Data.Services.Interfaz
{
    public interface IProductosServices
    {
        Task<List<ProductosDto>> GetAll();
    }
}
