using System.ComponentModel.DataAnnotations;

namespace SistemaRentaAutos.Models;

public class Auto
{
    public int AutoID { get; set; }
    [StringLength(50)]
    public string? Marca { get; set; }
    [StringLength(50)]
    public string? Modelo { get; set; }
    public int? Anio { get; set; }
    [StringLength(15)]
    public string? Placa { get; set; }
    [StringLength(30)]
    public string? Color { get; set; }
    [StringLength(30)]
    public string? TipoCombustible { get; set; }
    public decimal? PrecioPorDia { get; set; }
    [StringLength(30)]
    public string? Estado { get; set; }
}
