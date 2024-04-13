using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController(IServicioService servicioService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateServicio([FromBody] ServicioDto servicioDto)
        {
            var result = await servicioService.CreateServicioAsync(servicioDto);
            return result == 1 ? Ok("Servicio created successfully.") : BadRequest("Failed to create servicio.");
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicioDto>>> GetAllServicios()
        {
            var servicios = await servicioService.GetServiciosAsync();
            return Ok(servicios);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateServicio([FromBody] ServicioDto servicioDto)
        {
            var result = await servicioService.UpdateServicioAsync(servicioDto);
            return result == 1 ? Ok("Servicio updated successfully.") : NotFound("Servicio not found.");
        }

        [HttpDelete("{servicioCodigo}")]
        public async Task<IActionResult> DeleteServicio(string servicioCodigo)
        {
            var result = await servicioService.DeleteServicioAsync(servicioCodigo);
            return result == 1 ? Ok("Servicio deleted successfully.") : NotFound("Servicio not found.");
        }
    }
}
