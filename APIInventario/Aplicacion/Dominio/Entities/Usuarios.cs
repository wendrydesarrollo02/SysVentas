using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace APISysVentas.Aplicacion.Dominio.Entities
{
    public class Usuarios
    {
        [Key]
        public int Id_User { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string rol { get; set; }
        public ClaimsIdentity Username { get; internal set; }
    }
}
