using APISysVentas.Aplicacion.Helpers;
using APISysVentas.Aplicacion.Infraestructura.DATA.Context;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//using APISysVentas.Aplicacion.

// Configuracion JWT para obtener Token
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{

    gen.SwaggerDoc("v1", new OpenApiInfo { Title = "APISysVentas", Version = "v1" });

    gen.AddSecurityDefinition("productos", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "Authorization Key",
    });

    var segurity = new OpenApiSecurityRequirement { {
        new OpenApiSecurityScheme
        {
          Reference = new OpenApiReference
          {
            Id = "productos",
            Type = ReferenceType.SecurityScheme
          },
          UnresolvedReference = true
        },
        new List<string>()

        } };
    gen.AddSecurityRequirement(segurity);

});

var Configuration = builder.Configuration;

//Connection SQLite
builder.Services.AddDbContext<DataDbContext>(x =>
{
    x.UseLazyLoadingProxies();
    x.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddSysVentasServicesDb(Configuration);
builder.Services.AddSysVentasService();

builder.Services.AddControllers();

var app = builder.Build();

//var configuracion = 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APISysVentas v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
