using APISysVentas.Aplicacion.Data.Context;
using APISysVentas.Aplicacion.Data.Services.Interfaz;
using APISysVentas.Aplicacion.Data.Services.Repository;
using APISysVentas.Aplicacion.Services.Interfaz;
using APISysVentas.Aplicacion.Services.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
                         op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
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
            services.AddDbContext<APIInventarioPatridgeDbContext>(db =>
            {
                db.UseMySQL("Server=127.0.0.1;Database=sysventasdb;Uid=root;Pwd=;", dbMySql =>
                {
                });
                db.UseLazyLoadingProxies();

            });

            services.AddScoped<IAPIInventarioPatridgeDbContext>(set => set.GetService<APIInventarioPatridgeDbContext>());
            return services;
        }

        //Service 
        public static IServiceCollection AddSysVentasService(this IServiceCollection services) 
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenSevice, TokenService>();
            services.AddScoped<IProductosServices, ProductosRepoServices>();


            return services;
        
        }

    }
}
