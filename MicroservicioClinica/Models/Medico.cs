namespace MicroservicioClinica.Models
{
    public class Medico
    {
        public int MedicoId { get; set; }

        public string Nombres { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string? Especialidad { get; set; }

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}