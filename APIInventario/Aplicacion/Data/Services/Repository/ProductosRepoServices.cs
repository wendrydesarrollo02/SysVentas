using APISysVentas.Aplicacion.Data.Services.Interfaz;
using APISysVentas.Aplicacion.Dominio.Dtos;
using APISysVentas.Aplicacion.Dominio.Entities;
using APISysVentas.Aplicacion.Services.Interfaz;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace APISysVentas.Aplicacion.Data.Services.Repository
{
    public class ProductosRepoServices : IProductosServices
    {

        private readonly IAPIInventarioPatridgeDbContext patridgeDbContext;
        public ProductosRepoServices(IAPIInventarioPatridgeDbContext aPIInventarioPatridgeDb)
        {
            patridgeDbContext = aPIInventarioPatridgeDb;
        }

        //public string conexion = "Data Source=sql10.freesqldatabase.com; database=sql10645379; user=sql10645379; password=Fw9K2BszKr";
        public async Task<List<productos>> GetAll()
        {


            var getProductos = await patridgeDbContext.productos.ToListAsync();
            return getProductos;
            #region PROCEDIMIENTO ALMACENADO 
            //List<productosDto> list = new();

            //using var cn = new MySqlConnection(conexion);
            //using var cmd = new MySqlCommand("SELECT * FROM productos", cn);
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Clear();

            //}

            //await cn.OpenAsync();
            //var reader = cmd.ExecuteReader();

            //while (await reader.ReadAsync())
            //{
            //    var productos = new productosDto()
            //    {
            //        cantidad_disponible = reader.GetInt32(0),
            //        categoria = reader.GetString(1),
            //        descripcion = reader.GetString(2),
            //        fecha_entrada = reader.GetDateTime(3),
            //        Id_producto = reader.GetInt32(4),
            //        nombre_producto = reader.GetString(5),
            //        precio = reader.GetDecimal(6),

            //    };

            //    list.Add(productos);

            //}

            //return list;
            #endregion
        }

        public async Task<List<productos>> GetByCategoria(string categoria)
        {


            //var getByCategoria = await  patridgeDbContext.productos.FirstOrDefaultAsync(x => x.Categoria == categoria);

            var getByCategoria = await patridgeDbContext.productos.Where(x => x.Categoria == categoria).ToListAsync();
            return getByCategoria;
        }

        public async Task<productos> GetById(int Id)
        {
            var getByIdProductos = await patridgeDbContext.productos.FirstOrDefaultAsync(x => x.Id_producto == Id);
            return getByIdProductos;
        }

        public async Task<productos> GetByName(string names)
        {
            var getByName = await patridgeDbContext.productos.FirstOrDefaultAsync(x => x.Nombre_producto == names);
            return getByName;
        }
    }
}
