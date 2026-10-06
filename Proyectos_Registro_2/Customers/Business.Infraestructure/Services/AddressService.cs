using Business.Core.Config;
using Business.Core.Dtos;
using Business.Core.Interfaces.Services;
using Common.Wrappers;
using Microsoft.Extensions.Options;
using NugetPackage_Rest.Interfaces.IServices;
using System.Threading.Tasks;

namespace Business.Infraestructure.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRest _rest;
        private readonly ApiAddressesConfig _config;

        public AddressService(
            IRest rest,
            IOptions<ApiAddressesConfig> config)
        {
            _rest = rest;
            _config = config.Value;
        }

        public async Task<HttpResponse<AddressDto>> AddAsync(AddressDto address)
        {
            return await _rest.Post
                .WithoutAuth()
                .WithUri(_config.BaseUrl, "Position")
                .WithBody(address)
                .DeserializeWithAsync<HttpResponse<AddressDto>>();
        }
    }
}