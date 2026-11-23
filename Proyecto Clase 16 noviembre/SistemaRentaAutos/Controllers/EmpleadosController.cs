using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaRentaAutos.Data;
using SistemaRentaAutos.Models;

namespace SistemaRentaAutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController(SistemaRentaAutosDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleado>>> GetAll(CancellationToken cancellationToken) =>
        await context.Empleados.AsNoTracking().ToListAsync(cancellationToken);

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Empleado>> GetById(int id, CancellationToken cancellationToken)
    {
        var empleado = await context.Empleados.AsNoTracking().FirstOrDefaultAsync(x => x.EmpleadoID == id, cancellationToken);
        return empleado is null ? NotFound() : Ok(empleado);
    }

    [HttpPost]
    public async Task<ActionResult<Empleado>> Create(Empleado empleado, CancellationToken cancellationToken)
    {
        context.Empleados.Add(empleado);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = empleado.EmpleadoID }, empleado);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Empleado empleado, CancellationToken cancellationToken)
    {
        if (id != empleado.EmpleadoID) return BadRequest("El ID de la ruta debe coincidir con EmpleadoID.");
        if (!await context.Empleados.AnyAsync(x => x.EmpleadoID == id, cancellationToken)) return NotFound();

        context.Entry(empleado).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var empleado = await context.Empleados.FindAsync([id], cancellationToken);
        if (empleado is null) return NotFound();
        context.Empleados.Remove(empleado);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
