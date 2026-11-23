using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaRentaAutos.Data;
using SistemaRentaAutos.Models;

namespace SistemaRentaAutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutosController(SistemaRentaAutosDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Auto>>> GetAll(CancellationToken cancellationToken) =>
        await context.Autos.AsNoTracking().ToListAsync(cancellationToken);

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Auto>> GetById(int id, CancellationToken cancellationToken)
    {
        var auto = await context.Autos.AsNoTracking().FirstOrDefaultAsync(x => x.AutoID == id, cancellationToken);
        return auto is null ? NotFound() : Ok(auto);
    }

    [HttpPost]
    public async Task<ActionResult<Auto>> Create(Auto auto, CancellationToken cancellationToken)
    {
        context.Autos.Add(auto);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = auto.AutoID }, auto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Auto auto, CancellationToken cancellationToken)
    {
        if (id != auto.AutoID) return BadRequest("El ID de la ruta debe coincidir con AutoID.");
        if (!await context.Autos.AnyAsync(x => x.AutoID == id, cancellationToken)) return NotFound();

        context.Entry(auto).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var auto = await context.Autos.FindAsync([id], cancellationToken);
        if (auto is null) return NotFound();
        context.Autos.Remove(auto);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
