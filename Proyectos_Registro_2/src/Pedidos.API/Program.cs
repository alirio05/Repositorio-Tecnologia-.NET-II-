using Newtonsoft.Json.Serialization;
using Pedidos.Core;
using Pedidos.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCore(builder.Configuration); // opciones + MediatR
builder.Services.AddInfraestructure(builder.Configuration); // IRest + servicios HTTP

var app = builder.Build();