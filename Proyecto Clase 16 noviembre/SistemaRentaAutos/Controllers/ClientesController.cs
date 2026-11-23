using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaRentaAutos.Data;
using SistemaRentaAutos.Models;

namespace SistemaRentaAutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController(SistemaRentaAutosDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAll(CancellationToken cancellationToken) =>
        await context.Clientes.AsNoTracking().ToListAsync(cancellationToken);

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Cliente>> GetById(int id, CancellationToken cancellationToken)
    {
        var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.ClienteID == id, cancellationToken);
        return cliente is null ? NotFound() : Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Create(Cliente cliente, CancellationToken cancellationToken)
    {
        context.Clientes.Add(cliente);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteID }, cliente);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Cliente cliente, CancellationToken cancellationToken)
    {
        if (id != cliente.ClienteID) return BadRequest("El ID de la ruta debe coincidir con ClienteID.");
        if (!await context.Clientes.AnyAsync(x => x.ClienteID == id, cancellationToken)) return NotFound();

        context.Entry(cliente).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var cliente = await context.Clientes.FindAsync([id], cancellationToken);
        if (cliente is null) return NotFound();
        context.Clientes.Remove(cliente);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
