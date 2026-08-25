using MediatR;

namespace MicroservicioClinica.Features.Citas.Commands
{
    public class CreateCitaCommand : IRequest<int>
    {
        public int PacienteId { get; set; }

        public int MedicoId { get; set; }

        public DateTime FechaCita { get; set; }

        public string? Motivo { get; set; }
    }
}
