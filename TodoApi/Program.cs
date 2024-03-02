using Microsoft.EntityFrameworkCore;
using TodoApi.Context;

var builder = WebApplication.CreateBuilder(args);

//Creando variable para cadena de conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("Connection");
//Registrando servicio para la conexión
builder.Services.AddDbContext<AppDbContext> (options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
