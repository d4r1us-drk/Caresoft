using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalaController(ISalaService salaService) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> CreateSala([FromQuery] SalaDto salaDto)
    {
        var result = await salaService.CreateSalaAsync(salaDto);
        if (result == 1)
            return Ok("Sala created successfully.");
        return BadRequest("Failed to create sala.");
    }

    [HttpGet("get")]
    public async Task<ActionResult<List<SalaDto>>> GetAllSalas()
    {
        var salas = await salaService.GetSalasAsync();
        return Ok(salas);
    }

    [HttpPut("update/{numSala}")]
    public async Task<IActionResult> UpdateSalaEstado(uint numSala)
    {
        var result = await salaService.UpdateSalaEstadoAsync(numSala);
        if (result == 1)
            return Ok("Sala estado updated successfully.");
        return NotFound("Sala not found.");
    }

    [HttpDelete("delete/{numSala}")]
    public async Task<IActionResult> DeleteSala(uint numSala)
    {
        var result = await salaService.DeleteSalaAsync(numSala);
        if (result == 1)
            return Ok("Sala deleted successfully.");
        return NotFound("Sala not found.");
    }
}