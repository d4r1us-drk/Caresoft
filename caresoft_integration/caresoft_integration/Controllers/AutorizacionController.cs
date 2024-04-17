using Microsoft.AspNetCore.Mvc;
using caresoft_integration.Models;
using caresoft_integration.Dto;
using caresoft_integration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace caresoft_integration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorizacionController : ControllerBase
{
    private readonly IAutorizacionService _autorizacionService;

    public AutorizacionController(IAutorizacionService autorizacionService)
    {
        _autorizacionService = autorizacionService;
    }

    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<AutorizacionDto>>> GetAllAutorizaciones()
    {
        try
        {
            var autorizaciones = await _autorizacionService.GetAllAutorizacionesAsync();
            return Ok(autorizaciones.Select(a => AutorizacionDto.FromAutorizacion(a)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<AutorizacionDto>> GetAutorizacion(uint id)
    {
        try
        {
            var autorizacion = await _autorizacionService.GetAutorizacionByIdAsync(id);
            if (autorizacion == null)
                return NotFound();
            return AutorizacionDto.FromAutorizacion(autorizacion);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("add")]
    public async Task<ActionResult<Autorizacion>> AddAutorizacion([FromBody] AutorizacionDto autorizacionDto)
    {
        try
        {
            var autorizacion = Autorizacion.FromDto(autorizacionDto);
            var result = await _autorizacionService.CreateAutorizacionAsync(autorizacion, null); // Assuming Aseguradora is managed separately
            if (result == 0)
                return BadRequest();
            return CreatedAtAction("GetAutorizacion", new { id = autorizacion.IdAutorizacion }, autorizacion);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAutorizacion([FromBody] AutorizacionDto autorizacionDto)
    {
        try
        {
            var autorizacion = Autorizacion.FromDto(autorizacionDto);
            var result = await _autorizacionService.UpdateAutorizacionAsync(autorizacion, null); // Assuming Aseguradora is managed separately
            if (result == 0)
                return NotFound();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAutorizacion(uint id)
    {
        try
        {
            var result = await _autorizacionService.DeleteAutorizacionAsync(id);
            if (result == 0)
                return NotFound();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
