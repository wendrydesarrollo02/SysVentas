using APISysVentas.Aplicacion.Aauthentication.Interfaz;
using APISysVentas.Aplicacion.Data.Context;
using APISysVentas.Aplicacion.Dominio.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace APISysVentas.Aplicacion.Aauthentication.Repository
{
    public class AuthenticationService : IAuthenticationServices
    {

        private readonly APIInventarioPatridgeDbContext _PatridgeDbContext;

        public AuthenticationService(APIInventarioPatridgeDbContext dbContext)
        {
            _PatridgeDbContext = dbContext;
        }


        public async Task<bool> ExisteUser(string email)
        {
            if(await _PatridgeDbContext.Users.AnyAsync(e => e.Email == email))
                return true;

            return false;

            //APISysVentas
        }

        public async Task<Users> LoginUser(string email, string password)
        {
            var loginUser = await _PatridgeDbContext.Users.FirstOrDefaultAsync(e => e.Email == email);
            if (loginUser == null)
                return null;

            if (!VerificarPasswordHash(password, loginUser.PasswordHash!, loginUser.PasswordSalt!))
                return null;

            return loginUser;
        }

        public async Task<Users> Registrar(Users users, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CrearPasswordHash(password, out passwordHash, out passwordSalt);
            users.PasswordHash = passwordHash;
            users.PasswordSalt = passwordSalt;

            await _PatridgeDbContext.Users.AddAsync(users);
            await _PatridgeDbContext.SaveChangesAsync();

            return users;

        }

        //METODO PARA VERIFICAR SI UN USUARIO SE ENCUENTRA REGISTRADO 
        private bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) 
        {
            using (var hmc = new System.Security.Cryptography.HMACSHA512(passwordSalt)) 
            {
                var computeHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computeHash.Length; i++) 
                {
                    if (computeHash[i] != passwordHash[i]) return false;
                }
            
            }
          return true;
        }

        //METODO PARA CREAR EL PASSWORD
        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using (var hamc = new System.Security.Cryptography.HMACSHA512()) 
            {
                passwordSalt = hamc.Key;
                passwordHash = hamc.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            }
        
        }
    }
}
