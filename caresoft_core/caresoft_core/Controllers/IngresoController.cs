using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngresoController(IIngresoService ingresoService) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddIngreso([FromQuery] IngresoDto ingresoDto)
    {
        try
        {
            var result = await ingresoService.AddIngresoAsync(ingresoDto);
            if (result == 1)
                return Ok("Ingreso added successfully.");
            return BadRequest("Failed to add ingreso.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateIngreso([FromQuery] IngresoDto ingresoDto)
    {
        try
        {
            var result = await ingresoService.UpdateIngresoAsync(ingresoDto);
            if (result == 1)
                return Ok("Ingreso updated successfully.");
            return NotFound("Ingreso not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteIngreso(uint id)
    {
        try
        {
            var result = await ingresoService.DeleteIngresoAsync(id);
            if (result == 1)
                return Ok("Ingreso deleted successfully.");
            return NotFound("Ingreso not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get")]
    public async Task<ActionResult<List<IngresoDto>?>> GetIngresos()
    {
        try
        {
            var ingresos = await ingresoService.GetIngresosAsync();
            return Ok(ingresos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<IngresoDto?>> GetIngresoById(uint id)
    {
        try
        {
            var ingreso = await ingresoService.GetIngresoByIdAsync(id);
            if (ingreso != null)
                return Ok(ingreso);
            return NotFound("Ingreso not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // Metodos con afecciones (relacion M:M)
    [HttpPost("{idIngreso}/afecciones/{idAfeccion}")]
    public async Task<IActionResult> AddIngresoAfeccion(uint idIngreso, uint idAfeccion)
    {
        var result = await ingresoService.AddIngresoAfeccionAsync(idIngreso, idAfeccion);
        return result == 1 ? Ok("Afección added successfully.") : NotFound("Ingreso or Afección not found.");
    }

    [HttpDelete("{idIngreso}/afecciones/{idAfeccion}")]
    public async Task<IActionResult> RemoveIngresoAfeccion(uint idIngreso, uint idAfeccion)
    {
        var result = await ingresoService.RemoveIngresoAfeccionAsync(idIngreso, idAfeccion);
        return result == 1 ? Ok("Afección removed successfully.") : NotFound("Ingreso or Afección not found.");
    }

    [HttpGet("{idIngreso}/afecciones")]
    public async Task<ActionResult<List<Afeccion>?>> GetIngresoAfecciones(uint idIngreso)
    {
        var afecciones = await ingresoService.GetIngresoAfeccionesAsync(idIngreso);
        return Ok(afecciones);
    }
}