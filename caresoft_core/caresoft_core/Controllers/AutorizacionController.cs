using Microsoft.AspNetCore.Mvc;
using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;

namespace caresoft_core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorizacionController(IAutorizacionService autorizacionService) : ControllerBase
{
    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<AutorizacionDto>>> GetAutorizacions()
    {
        try
        {
            return (await autorizacionService.GetAutorizaciones())
                .Select(s => AutorizacionDto.FromAutorizacion(s))
                .ToList();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las autorizaciones");
        }
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<AutorizacionDto>> GetAutorizacion(uint id)
    {
        try
        {
            var autorizacion = await autorizacionService.GetAutorizacionById(id);

            if (autorizacion == null)
            {
                return NotFound();
            }

            return AutorizacionDto.FromAutorizacion(autorizacion);
        } catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la autorizacion");
        }

    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAutorizacion([FromQuery] AutorizacionDto autorizacionDto)
    {
        try
        {
            var autorizacion = Autorizacion.FromDto(autorizacionDto);
            await autorizacionService.UpdateAutorizacionAsync(autorizacion);
            return Ok();
        } catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la autorizacion");
        }

    }

    [HttpPost("add")]
    public async Task<ActionResult<int>> PostAutorizacion([FromQuery] AutorizacionDto autorizacionDto,
        int? idIngreso,
        string? consultaCodigo,
        string? facturaCodigo,
        string? servicioCodigo,
        int? idProducto)
    {
        try
        {
            var autorizacion = Autorizacion.FromDto(autorizacionDto);
            var result = await autorizacionService.AddAutorizacion(autorizacion, idIngreso, consultaCodigo, facturaCodigo, servicioCodigo, idProducto);
            if(result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la autorizacion");
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAutorizacion(uint id)
    {
        try
        {
            var result = await autorizacionService.DeleteAutorizacionAsync(id);
            if(result == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la autorizacion");
        }

    }
}