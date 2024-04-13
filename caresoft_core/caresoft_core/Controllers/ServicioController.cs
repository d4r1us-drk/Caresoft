using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateServicio([FromBody] ServicioDto servicioDto)
        {
            var result = await _servicioService.CreateServicioAsync(servicioDto);
            return result == 1 ? Ok("Servicio created successfully.") : BadRequest("Failed to create servicio.");
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicioDto>>> GetAllServicios()
        {
            var servicios = await _servicioService.GetServiciosAsync();
            return Ok(servicios);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateServicio([FromBody] ServicioDto servicioDto)
        {
            var result = await _servicioService.UpdateServicioAsync(servicioDto);
            return result == 1 ? Ok("Servicio updated successfully.") : NotFound("Servicio not found.");
        }

        [HttpDelete("{servicioCodigo}")]
        public async Task<IActionResult> DeleteServicio(string servicioCodigo)
        {
            var result = await _servicioService.DeleteServicioAsync(servicioCodigo);
            return result == 1 ? Ok("Servicio deleted successfully.") : NotFound("Servicio not found.");
        }
    }
}
