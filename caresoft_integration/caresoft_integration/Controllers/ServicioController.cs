using caresoft_integration.Dto;
using caresoft_integration.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_integration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicioController(IServicioService servicioService) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> CreateServicio([FromBody] ServicioDto servicioDto)
    {
        var result = await servicioService.CreateServicioAsync(servicioDto);
        return result == 1 ? Ok("Servicio created successfully.") : BadRequest("Failed to create servicio.");
    }

    [HttpGet("get")]
    public async Task<ActionResult<List<ServicioDto>>> GetAllServicios()
    {
        var servicios = await servicioService.GetServiciosAsync();
        return Ok(servicios);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateServicio([FromBody] ServicioDto servicioDto)
    {
        var result = await servicioService.UpdateServicioAsync(servicioDto);
        return result == 1 ? Ok("Servicio updated successfully.") : NotFound("Servicio not found.");
    }

    [HttpDelete("delete/{servicioCodigo}")]
    public async Task<IActionResult> DeleteServicio(string servicioCodigo)
    {
        var result = await servicioService.DeleteServicioAsync(servicioCodigo);
        return result == 1 ? Ok("Servicio deleted successfully.") : NotFound("Servicio not found.");
    }
}