using APISysVentas.Aplicacion.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//using APISysVentas.Aplicacion.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;

builder.Services.AddSysVentasServicesDb(Configuration);
builder.Services.AddSysVentasService();

builder.Services.AddControllers();

var app = builder.Build();

//var configuracion = 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
