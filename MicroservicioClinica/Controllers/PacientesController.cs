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
    }
}
