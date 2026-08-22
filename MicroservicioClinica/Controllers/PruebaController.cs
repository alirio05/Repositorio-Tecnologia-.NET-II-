using Microsoft.AspNetCore.Mvc;

namespace MicroservicioClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PruebaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("MicroservicioClinica funcionando correctamente");
        }
    }
}