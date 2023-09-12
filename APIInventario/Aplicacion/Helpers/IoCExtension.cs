using APISysVentas.Aplicacion.Aauthentication.Interfaz;
using APISysVentas.Aplicacion.Aauthentication.Repository;
using APISysVentas.Aplicacion.Data.Context;
using APISysVentas.Aplicacion.Data.Services.Interfaz;
using APISysVentas.Aplicacion.Data.Services.Repository;
using APISysVentas.Aplicacion.Mappers;
using APISysVentas.Aplicacion.Services.Interfaz;
using APISysVentas.Aplicacion.Services.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace APISysVentas.Aplicacion.Helpers
{
    public static class IoCExtension
    {
        public static IConfiguration Configuration { get; }

        //Configuration service JWTToken
        public static IServiceCollection TokenAPISysVentas(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(op =>
                     {
                         op.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuerSigningKey = true,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                             ValidateIssuer = false,
                             ValidateAudience = false
                         };

                     });
            return services;

        }

        //Service API Connection DB MySQL
        public static IServiceCollection AddSysVentasServicesDb(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceVersion = new MySqlServerVersion(new Version(3, 3, 0));
            string connectionString = Configuration.GetConnectionString("APIInventarioPatridgeDbContext");
            services.AddDbContext<APIInventarioPatridgeDbContext>(db => db.UseMySql("Server=sql10.freesqldatabase.com; database=sql10645379; user=sql10645379; password=Fw9K2BszKr;", serviceVersion));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<APIInventarioPatridgeDbContext>();

            //db.UseMySQL("Server=localhost;Database=sysventadb;Uid=root;Pwd=;", dbMySql =>
            //{
            //});
            //db.UseLazyLoadingProxies();

            services.AddScoped<IAPIInventarioPatridgeDbContext>(set => set.GetService<APIInventarioPatridgeDbContext>());
            return services;
        }

        //Service 
        public static IServiceCollection AddSysVentasService(this IServiceCollection services)
        {

            services.AddScoped(typeof(IAuthenticationServices), typeof(AuthenticationServices));
            services.AddScoped<ITokenSevice, TokenService>();
            services.AddScoped<IProductosServices, ProductosRepoServices>();
            services.AddScoped<IUsuariosServicesToken, UsuariosServicesToken>();


            services.AddAutoMapper(typeof(AutoMapperSysVentas).Assembly);
            return services;

        }

    }
}
