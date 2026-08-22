namespace MicroservicioClinica.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }

        public string Nombres { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public DateTime? FechaNacimiento { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}