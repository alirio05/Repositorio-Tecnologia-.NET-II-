using Business.Core.Interfaces.Services;
using Business.Infraestructure.Mapper;
using Business.Infraestructure.Services;
using Microsoft.Extensions.DependencyInjection;
using NugetPackage_Rest.Builders;
using NugetPackage_Rest.Interfaces.IServices;

namespace Business.Infraestructure
{
    public static class Extension
    {
        public static IServiceCollection AddInfraestructure(
            this IServiceCollection services)
        {
            services.AddHttpClient<IRest, RestBuilder>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddAutoMapper(config => config.AddProfile<MapperProfile>());

            return services;
        }
    }
}