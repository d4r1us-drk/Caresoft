using Microsoft.AspNetCore.Mvc;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Models;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AfeccionController : ControllerBase
{
    private readonly IAfeccionService _afeccionService;

    public AfeccionController(IAfeccionService afeccionService)
    {
        _afeccionService = afeccionService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddAfeccion([FromBody] Afeccion afeccion)
    {
        var result = await _afeccionService.CreateAfeccionAsync(afeccion);
        if (result == 1)
        {
            return Ok("Afeccion added successfully.");
        }
        return BadRequest("Failed to add Afeccion.");
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetAllAfecciones()
    {
        var afecciones = await _afeccionService.GetAfeccionesAsync();
        return Ok(afecciones);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetAfeccionById(uint id)
    {
        var afeccion = await _afeccionService.GetAfeccionByIdAsync(id);
        if (afeccion != null)
        {
            return Ok(afeccion);
        }
        return NotFound($"Afeccion with ID {id} not found.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAfeccion(Afeccion afeccion)
    {
        try
        {
            await _afeccionService.UpdateAfeccionAsync(afeccion);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAfeccion(uint id)
    {
        try
        {
            var result = await _afeccionService.DeleteAfeccionAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}