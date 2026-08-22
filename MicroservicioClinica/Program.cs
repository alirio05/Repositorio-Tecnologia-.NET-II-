using Microsoft.EntityFrameworkCore;
using MicroservicioClinica.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Conexión a ClinicaDB
builder.Services.AddDbContext<ClinicaDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ClinicaDB")));

// Conexión a SeguridadDB
builder.Services.AddDbContext<SeguridadDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SeguridadDB")));

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