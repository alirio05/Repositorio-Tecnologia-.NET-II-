using System.ComponentModel.DataAnnotations;

namespace SistemaRentaAutos.Models;

public class Renta
{
    public int RentaID { get; set; }
    public int? ClienteID { get; set; }
    public int? AutoID { get; set; }
    public int? EmpleadoID { get; set; }
    public DateOnly? FechaInicio { get; set; }
    public DateOnly? FechaFin { get; set; }
    public int? CantidadDias { get; set; }
    public decimal? TotalRenta { get; set; }
    [StringLength(30)]
    public string? Estado { get; set; }
}
