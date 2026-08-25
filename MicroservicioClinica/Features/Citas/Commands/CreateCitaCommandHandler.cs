using MediatR;
using MicroservicioClinica.Data;
using MicroservicioClinica.Models;

namespace MicroservicioClinica.Features.Citas.Commands
{
    public class CreateCitaCommandHandler : IRequestHandler<CreateCitaCommand, int>
    {
        private readonly ClinicaDBContext _context;

        public CreateCitaCommandHandler(ClinicaDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(
            CreateCitaCommand request,
            CancellationToken cancellationToken)
        {
            var cita = new Cita
            {
                PacienteId = request.PacienteId,
                MedicoId = request.MedicoId,
                FechaCita = request.FechaCita,
                Motivo = request.Motivo
            };

            _context.Citas.Add(cita);

            await _context.SaveChangesAsync(cancellationToken);

            return cita.CitaId;
        }
    }
}
