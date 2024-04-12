using Microsoft.AspNetCore.Mvc;
using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;

namespace caresoft_core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorizacionController : ControllerBase
{
    private readonly IAutorizacionService _autorizacionService;

    public AutorizacionController(IAutorizacionService autorizacionService)
    {
        _autorizacionService = autorizacionService;
    }

    // GET: api/Autorizacions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AutorizacionDto>>> GetAutorizacions()
    {
        try
        {
            return (await _autorizacionService.ListarAutorizaciones())
                .Select(s => AutorizacionDto.FromAutorizacion(s))
                .ToList();
        } catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las autorizaciones");
        }
    }

    // GET: api/Autorizacions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AutorizacionDto>> GetAutorizacion(uint id)
    {
        try
        {
            var autorizacion = await _autorizacionService.GetAutorizacionById(id);

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

    // PUT: api/Autorizacions/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAutorizacion(uint id, AutorizacionDto autorizacionDto)
    {
        if (id != autorizacionDto.IdAutorizacion)
        {
            return BadRequest();
        }

        try
        {
            var autorizacion = Autorizacion.FromDto(autorizacionDto);
            await _autorizacionService.ActualizarAutorizacion(autorizacion);
            return Ok();
        } catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la autorizacion");
        }

    }

    // POST: api/Autorizacions
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Autorizacion>> PostAutorizacion(AutorizacionDto autorizacionDto)
    {
        try
        {

            var autorizacion = Autorizacion.FromDto(autorizacionDto);
            var result = await _autorizacionService.CrearAutorizacion(autorizacion);
            if(result == 0)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetAutorizacion", new { id = autorizacion.IdAutorizacion }, autorizacion);
        } catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la autorizacion");
        }
    }

    // DELETE: api/Autorizacions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAutorizacion(uint id)
    {
        try
        {
            var result = await _autorizacionService.EliminarAutorizacion(id);
            if(result == 0)
            {
                return NotFound();
            }
            return Ok();
        } catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la autorizacion");
        }

    }


}