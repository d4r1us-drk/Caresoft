using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_integration.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AfeccionController(IAfeccionService afeccionService) : ControllerBase
{
    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<Afeccion>>> GetAfecciones()
    {
        try
        {
            var afecciones = await afeccionService.GetAfeccionesAsync();
            return Ok(afecciones);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Afeccion>> GetAfeccionById(uint id)
    {
        try
        {
            var afeccion = await afeccionService.GetAfeccionByIdAsync(id);
            if (afeccion == null)
            {
                return NotFound();
            }
            return Ok(afeccion);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreateAfeccion([FromQuery] Afeccion afeccion)
    {
        try
        {
            var result = await afeccionService.CreateAfeccionAsync(afeccion);
            if (result == 1)
            {
                return Ok("Afeccion created successfully");
            }
            return BadRequest("Unable to create afeccion");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("update/")]
    public async Task<IActionResult> UpdateAfeccion([FromQuery] Afeccion afeccion)
    {
        try
        {
            var result = await afeccionService.UpdateAfeccionAsync(afeccion);
            if (result == 1)
            {
                return Ok("Afeccion updated successfully");
            }
            return NotFound("Afeccion not found");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAfeccion(uint id)
    {
        try
        {
            var result = await afeccionService.DeleteAfeccionAsync(id);
            if (result == 1)
            {
                return Ok("Afeccion deleted successfully");
            }
            return NotFound("Afeccion not found");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}