using APISysVentas.Aplicacion.Data.Services.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISysVentas.Aplicacion.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
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
            if(getProductos == null)
                return BadRequest("NO HAY PRODUCTOS REGISTRADO" + "GRACIAS POR PREFERIRNO");

            return Ok(getProductos);
        }
    }
}
