using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicioClinica.Data;
using Nuget_Persistence.Abstractions;
using Nuget_Persistence.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registrar MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Conexión a ClinicaDB
builder.Services.AddDbContext<ClinicaDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ClinicaDB")));

// Conexión a SeguridadDB
builder.Services.AddDbContext<SeguridadDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SeguridadDB")));

// Registrar DbContext para el repositorio genérico
builder.Services.AddScoped<DbContext>(serviceProvider =>
    serviceProvider.GetRequiredService<ClinicaDBContext>());

// Registrar repositorio genérico
builder.Services.AddScoped(
    typeof(IRepository<>),
    typeof(Repository<>));

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
