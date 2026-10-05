using Pedidos.Core.Services;
using Pedidos.Infraestructure.Services;
using NugetPackage_Rest.Builders;
using NugetPackage_Rest.Extensions;
using NugetPackage_Rest.Interfaces.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pedidos.Infraestructure
{
    public static class Extension
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Enlaza "RestSettings" → IOptions<RequestSettings>
            services.AddRequestLogging(configuration);

            // 2. Registra IRest como typed client de IHttpClientFactory
            services.AddHttpClient<IRest, RestBuilder>();

            // 3. Registra los servicios que usan IRest
            services.AddScoped<IPagoService, PagoService>();

            return services;
        }
    }
}