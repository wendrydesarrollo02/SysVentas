using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace APISysVentas.Aplicacion.Dominio.Entities
{
    public class productos
    {
        [Key]
        public int Id_producto { get; set; }
        public string Nombre_producto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad_disponible { get; set; }
        public string Categoria { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public DateTime? Fecha_Deleted { get; set; }
        public DateTime? Ultimo_Updated { get; set; }
    }
}
