using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaRentaAutos.Data;
using SistemaRentaAutos.Models;

namespace SistemaRentaAutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagosController(SistemaRentaAutosDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pago>>> GetAll(CancellationToken cancellationToken) =>
        await context.Pagos.AsNoTracking().ToListAsync(cancellationToken);

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Pago>> GetById(int id, CancellationToken cancellationToken)
    {
        var pago = await context.Pagos.AsNoTracking().FirstOrDefaultAsync(x => x.PagoID == id, cancellationToken);
        return pago is null ? NotFound() : Ok(pago);
    }

    [HttpPost]
    public async Task<ActionResult<Pago>> Create(Pago pago, CancellationToken cancellationToken)
    {
        context.Pagos.Add(pago);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = pago.PagoID }, pago);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Pago pago, CancellationToken cancellationToken)
    {
        if (id != pago.PagoID) return BadRequest("El ID de la ruta debe coincidir con PagoID.");
        if (!await context.Pagos.AnyAsync(x => x.PagoID == id, cancellationToken)) return NotFound();

        context.Entry(pago).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
