namespace MicroservicioClinica.Models
{
    public class Cita
    {
        public int CitaId { get; set; }

        public int PacienteId { get; set; }

        public int MedicoId { get; set; }

        public DateTime FechaCita { get; set; }

        public string? Motivo { get; set; }

        public Paciente Paciente { get; set; } = null!;

        public Medico Medico { get; set; } = null!;
    }
}