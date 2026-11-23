using System.ComponentModel.DataAnnotations;

namespace SistemaRentaAutos.Models;

public class Empleado
{
    public int EmpleadoID { get; set; }
    [StringLength(100)]
    public string? Nombre { get; set; }
    [StringLength(100)]
    public string? Apellido { get; set; }
    [StringLength(50)]
    public string? Cargo { get; set; }
    [StringLength(20)]
    public string? Telefono { get; set; }
    [StringLength(100)]
    public string? Correo { get; set; }
    public DateOnly? FechaContratacion { get; set; }
    public decimal? Salario { get; set; }
}
