using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SistemaRentaAutos.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<SistemaRentaAutosDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SistemaRentaAutos");
    if (!string.IsNullOrWhiteSpace(connectionString))
    {
        options.UseSqlServer(connectionString);
    }
});

var app = builder.Build();

app.UseExceptionHandler(exceptionHandler => exceptionHandler.Run(async context =>
{
    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    await context.Response.WriteAsJsonAsync(new ProblemDetails
    {
        Status = StatusCodes.Status500InternalServerError,
        Title = "Ocurrió un error al procesar la solicitud."
    });
}));
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();
