using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaRentaAutos.Data;
using SistemaRentaAutos.Models;

namespace SistemaRentaAutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentasController(SistemaRentaAutosDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Renta>>> GetAll(CancellationToken cancellationToken) =>
        await context.Rentas.AsNoTracking().ToListAsync(cancellationToken);

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Renta>> GetById(int id, CancellationToken cancellationToken)
    {
        var renta = await context.Rentas.AsNoTracking().FirstOrDefaultAsync(x => x.RentaID == id, cancellationToken);
        return renta is null ? NotFound() : Ok(renta);
    }

    [HttpPost]
    public async Task<ActionResult<Renta>> Create(Renta renta, CancellationToken cancellationToken)
    {
        context.Rentas.Add(renta);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = renta.RentaID }, renta);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Renta renta, CancellationToken cancellationToken)
    {
        if (id != renta.RentaID) return BadRequest("El ID de la ruta debe coincidir con RentaID.");
        if (!await context.Rentas.AnyAsync(x => x.RentaID == id, cancellationToken)) return NotFound();

        context.Entry(renta).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
