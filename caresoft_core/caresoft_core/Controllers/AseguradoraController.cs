using Microsoft.AspNetCore.Mvc;
using caresoft_core.Models;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;

namespace caresoft_core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AseguradoraController(IAseguradoraService aseguradoraService) : ControllerBase
{
    private readonly LogHandler<AseguradoraController> _logHandler = new();

    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<Aseguradora>>> GetAseguradoras()
    {
        try
        {
            return await aseguradoraService.GetAllAseguradoras();

        } catch (Exception ex)
        {
            _logHandler.LogFatal("Error al obtener las aseguradoras", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las aseguradoras");
        }
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Aseguradora>> GetAseguradora(uint id)
    {
        try
        {
            var aseguradora = await aseguradoraService.GetAseguradoraById(id);

            if (aseguradora == null)
            {
                return NotFound();
            }

            return aseguradora;
        } catch (Exception ex)
        {
            _logHandler.LogFatal("Error al obtener la aseguradora", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la aseguradora");
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAseguradora([FromQuery] Aseguradora aseguradora)
    {
        try
        {
            var updated = await aseguradoraService.UpdateAseguradora(aseguradora);

            if (updated == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al actualizar la aseguradora", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la aseguradora");
        }
    }

    [HttpPost("add")]
    public async Task<ActionResult<Aseguradora>> PostAseguradora([FromQuery] Aseguradora aseguradora)
    {
        try
        {
            var newAseguradora = await aseguradoraService.CreateAseguradora(aseguradora);
            if(newAseguradora == 0)
            {
                return Conflict();
            }
            return CreatedAtAction("GetAseguradora", new { id = aseguradora.IdAseguradora }, aseguradora);
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al crear la aseguradora", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la aseguradora");
        }

    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAseguradora(uint id)
    {
        try
        {
            var aseguradora = await aseguradoraService.GetAseguradoraById(id);

            if (aseguradora == null)
            {
                return NotFound();
            }

            var deleted = await aseguradoraService.DeleteAseguradora(id);

            if (deleted == 1)
            {
                return Ok();
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al eliminar la aseguradora", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la aseguradora");
        }

    }
}