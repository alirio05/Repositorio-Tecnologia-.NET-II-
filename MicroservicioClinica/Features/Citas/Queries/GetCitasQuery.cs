using MediatR;
using MicroservicioClinica.Models;

namespace MicroservicioClinica.Features.Citas.Queries
{
    public class GetCitasQuery : IRequest<List<Cita>>
    {
    }
}
