using Microsoft.AspNetCore.Mvc;
using MicroservicioClinica.Models;
using Nuget_Persistence.Abstractions;

namespace MicroservicioClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IRepository<Paciente> _repository;

        public PacientesController(IRepository<Paciente> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPacientes(
            int pageNumber = 1,
            int pageSize = 10,
            string? orderBy = "Nombres",
            bool orderDescending = false)
        {
            var result = await _repository.GetPagedAsync(
                pageNumber,
                pageSize,
                orderBy: orderBy,
                orderDescending: orderDescending
            );

            return Ok(result);
        }

        [HttpGet("one")]
        public async Task<ActionResult> GetOnePaciente(
            string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return BadRequest(
                    "El nombre del paciente es requerido.");
            }

            var paciente = await _repository.GetOneByAsync(
                p => p.Nombres == nombre
            );

            if (paciente == null)
            {
                return NotFound(
                    $"No se encontró un paciente con el nombre '{nombre}'.");
            }

            return Ok(paciente);
        }

        [HttpPost("range")]
        public async Task<ActionResult> AddRange(
            List<Paciente> pacientes,
            CancellationToken cancellationToken)
        {
            if (pacientes == null || pacientes.Count == 0)
            {
                return BadRequest(
                    "Debe enviar al menos un paciente.");
            }

            await _repository.AddRangeAsync(
                pacientes,
                cancellationToken);

            int registrosGuardados = await _repository.SaveChangesAsync(
                cancellationToken);

            return Ok(new
            {
                mensaje = "Pacientes agregados correctamente.",
                cantidad = pacientes.Count,
                registrosGuardados = registrosGuardados
            });
        }
    }
}
