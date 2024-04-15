using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultorioController(IConsultorioService consultorioService) : ControllerBase
{
    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<Consultorio>>> GetConsultorios()
    {
        try
        {
            var consultorios = await consultorioService.GetConsultoriosAsync();
            return Ok(consultorios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error {ex.Message}");
        }
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Consultorio?>> GetConsultorioById(uint id)
    {
        try
        {
            var consultorio = await consultorioService.GetConsultorioByIdAsync(id);
            if (consultorio == null)
            {
                return NotFound();
            }
            return Ok(consultorio);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error {ex.Message}");
        }
    }

    [HttpPost("add")]
    public async Task<ActionResult> CreateConsultorio([FromQuery] Consultorio consultorio)
    {
        try
        {
            var result = await consultorioService.CreateConsultorioAsync(consultorio);
            if (result == 1)
            {
                return CreatedAtAction(nameof(GetConsultorioById), new { id = consultorio.IdConsultorio }, consultorio);
            }
            return StatusCode(500, "Failed to create Consultorio");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error {ex.Message}");
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateConsultorio([FromQuery] Consultorio consultorio)
    {
        try
        {
            var result = await consultorioService.UpdateConsultorioAsync(consultorio);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error {ex.Message}");
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteConsultorio(uint id)
    {
        try
        {
            var result = await consultorioService.DeleteConsultorioAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error {ex.Message}");
        }
    }
}