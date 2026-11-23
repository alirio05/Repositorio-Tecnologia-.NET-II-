using System.ComponentModel.DataAnnotations;

namespace SistemaRentaAutos.Models;

public class Cliente
{
    public int ClienteID { get; set; }
    [StringLength(100)]
    public string? Nombre { get; set; }
    [StringLength(100)]
    public string? Apellido { get; set; }
    [StringLength(15)]
    public string? DUI { get; set; }
    [StringLength(20)]
    public string? Telefono { get; set; }
    [StringLength(100)]
    public string? Correo { get; set; }
    [StringLength(200)]
    public string? Direccion { get; set; }
    public DateOnly? FechaRegistro { get; set; }
}
