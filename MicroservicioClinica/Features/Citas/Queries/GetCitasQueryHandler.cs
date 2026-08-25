using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicioClinica.Data;
using MicroservicioClinica.Models;

namespace MicroservicioClinica.Features.Citas.Queries
{
    public class GetCitasQueryHandler : IRequestHandler<GetCitasQuery, List<Cita>>
    {
        private readonly ClinicaDBContext _context;

        public GetCitasQueryHandler(ClinicaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Cita>> Handle(
            GetCitasQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Citas
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
