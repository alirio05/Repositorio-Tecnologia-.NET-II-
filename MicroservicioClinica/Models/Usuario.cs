namespace MicroservicioClinica.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public int RolId { get; set; }

        public Rol Rol { get; set; } = null!;
    }
}