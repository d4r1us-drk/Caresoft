using Microsoft.AspNetCore.Mvc;
using caresoft_core.Models;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;

namespace caresoft_core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AseguradoraController : ControllerBase
{

    private readonly IAseguradoraService _aseguradoraService;
    private readonly LogHandler<AseguradoraController> _logHandler = new();

    public AseguradoraController(IAseguradoraService aseguradoraService)
    {
        _aseguradoraService = aseguradoraService;
    }
    // GET: api/Aseguradora
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aseguradora>>> GetAseguradoras()
    {
        try
        {
            return await _aseguradoraService.GetAllAseguradoras();

        } catch (Exception ex)
        {
            _logHandler.LogFatal("Error al obtener las aseguradoras", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las aseguradoras");
        }
    }

    // GET: api/Aseguradora/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Aseguradora>> GetAseguradora(uint id)
    {
        try
        {
            var aseguradora = await _aseguradoraService.GetAseguradoraById(id);

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

    // PUT: api/Aseguradora/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAseguradora(uint id, Aseguradora aseguradora)
    {
        try
        {
            if (id != aseguradora.IdAseguradora)
            {
                return BadRequest();
            }

            int updated = await _aseguradoraService.UpdateAseguradora(aseguradora);

            if (updated == 0)
            {
                return NotFound();
            }
            return Ok();
        } catch (Exception ex)
        {
            _logHandler.LogFatal("Error al actualizar la aseguradora", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la aseguradora");
        }
    }

    // POST: api/Aseguradora
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Aseguradora>> PostAseguradora(Aseguradora aseguradora)
    {
        try
        {
            int newAseguradora = await _aseguradoraService.CreateAseguradora(aseguradora);
            if(newAseguradora == 0)
            {
                return Conflict();
            }
            return CreatedAtAction("GetAseguradora", new { id = aseguradora.IdAseguradora }, aseguradora);
        } catch (Exception ex)
        {
            _logHandler.LogFatal("Error al crear la aseguradora", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la aseguradora");
        }

    }

    // DELETE: api/Aseguradora/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAseguradora(uint id)
    {
        try
        {
            Aseguradora? aseguradora = await _aseguradoraService.GetAseguradoraById(id);

            if (aseguradora == null)
            {
                return NotFound();
            }

            int deleted = await _aseguradoraService.DeleteAseguradora(id);

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