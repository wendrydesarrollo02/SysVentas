using APISysVentas.Aplicacion.Data.Services.Interfaz;
using APISysVentas.Aplicacion.Dominio.Dtos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace APISysVentas.Aplicacion.Data.Services.Repository
{
    public class ProductosRepoServices : IProductosServices
    {
        public string conexion = "Server=127.0.0.1;Database=sysventasdb;Uid=root;Pwd=;";
        public async Task<List<ProductosDto>> GetAll()
        {

            List<ProductosDto> list = new();

            using var cn = new MySqlConnection(conexion);
            using var cmd = new MySqlCommand("", cn);
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

            }

            await cn.OpenAsync();
            var reader = cmd.ExecuteReader();

            while (await reader.ReadAsync()) 
            {
                var productos = new ProductosDto()
                {
                    cantidad_disponible = reader.GetInt32(0),
                    categoria = reader.GetString(1),
                    descripcion = reader.GetString(2),
                    fecha_entrada = reader.GetDateTime(3),
                    Id_producto = reader.GetInt32(4),
                    nombre_producto = reader.GetString(5),
                    precio = reader.GetDecimal(6),

                };

                list.Add(productos);
                        
            }

            return list;
        
        }
    }
}
