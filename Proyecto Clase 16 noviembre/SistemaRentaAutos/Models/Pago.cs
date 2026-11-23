using System.ComponentModel.DataAnnotations;

namespace SistemaRentaAutos.Models;

public class Pago
{
    public int PagoID { get; set; }
    public int? ClienteID { get; set; }
    public int? RentaID { get; set; }
    public DateOnly? FechaPago { get; set; }
    [StringLength(50)]
    public string? MetodoPago { get; set; }
    public decimal? Monto { get; set; }
    [StringLength(30)]
    public string? EstadoPago { get; set; }
    [StringLength(50)]
    public string? Referencia { get; set; }
}
