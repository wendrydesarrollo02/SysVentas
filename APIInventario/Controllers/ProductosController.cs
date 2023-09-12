using APISysVentas.Aplicacion.Data.Services.Interfaz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISysVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosServices _ProductosServices;

        public ProductosController(IProductosServices productosServices)
        {
            _ProductosServices = productosServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getProductos = await _ProductosServices.GetAll();
            if (getProductos == null)
                return BadRequest("NO HAY PRODUCTOS REGISTRADO" + "GRACIAS POR PREFERIRNO");

            return Ok(getProductos);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var getByIdProducto = await _ProductosServices.GetById(Id);
            if (getByIdProducto == null)
                return BadRequest("EL ID NO COINCIDE CON NINGUN PRODUCTOS");

            return Ok(getByIdProducto);

        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var getByNameProductos = await _ProductosServices.GetByName(name);
            if (getByNameProductos == null)
                return BadRequest("EL NOMBRE DEL PRODUCTO NO FUE ENCONTRADO" + "ESTE PRODUCTO NO ESTA DISPONIBLE");

            return Ok(getByNameProductos);

        }

        [HttpGet("categoria/{categoria}")]
        public async Task<IActionResult> GetCategoria(string categoria) 
        {
            var getByCategoria = await _ProductosServices.GetByCategoria(categoria);
            if (getByCategoria == null)
                return BadRequest("ESTA CATEGORIA NO EXISTE" + "NO SE ENCONTRO NINGUN PRODUCTO CON ESTA CATEGORIA");

            return Ok(getByCategoria);
        
        
        }
    }
}
