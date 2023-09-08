namespace APISysVentas.Aplicacion.Dominio.Dtos
{
    public class UsersDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
