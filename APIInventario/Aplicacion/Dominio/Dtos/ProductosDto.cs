namespace APISysVentas.Aplicacion.Dominio.Dtos
{
    public class ProductosDto
    {
        public int Id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int cantidad_disponible { get; set; }
        public string categoria { get; set; }
        public DateTime fecha_entrada { get; set; }
    }
}
