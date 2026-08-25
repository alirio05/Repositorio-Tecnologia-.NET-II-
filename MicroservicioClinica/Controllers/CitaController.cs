using MediatR;
using Microsoft.AspNetCore.Mvc;
using MicroservicioClinica.Features.Citas.Commands;
using MicroservicioClinica.Features.Citas.Queries;

namespace MicroservicioClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCitas()
        {
            var citas = await _mediator.Send(new GetCitasQuery());

            return Ok(citas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCita(
            [FromBody] CreateCitaCommand command)
        {
            var citaId = await _mediator.Send(command);

            return Ok(new
            {
                CitaId = citaId,
                Mensaje = "Cita creada correctamente"
            });
        }
    }
}
