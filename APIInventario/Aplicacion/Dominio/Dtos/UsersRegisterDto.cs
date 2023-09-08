namespace APISysVentas.Aplicacion.Dominio.Dtos
{
    public class UsersRegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordUser { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set;}
    }
}
