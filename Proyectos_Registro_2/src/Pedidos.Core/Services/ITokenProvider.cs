namespace Pedidos.Core.Services
{
    public interface ITokenProvider
    {
        Task<string> GetTokenAsync(CancellationToken cancellationToken = default);
    }
}