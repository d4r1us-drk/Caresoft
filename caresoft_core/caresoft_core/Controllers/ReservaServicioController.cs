using caresoft_core.Dto;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservaServicioController(IReservaServicioService reservaServicioService) : ControllerBase
{
    private readonly LogHandler<ReservaServicioController> _logHandler = new();

    [HttpGet("get")]
    public async Task<ActionResult<List<ReservaServicioDto>>> GetReservaServiciosListAsync()
    {
        try
        {
            var reservas = await reservaServicioService.GetReservaServiciosListAsync();

            return Ok(reservas);
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("An error occurred while fetching reservation services.", ex);
            return StatusCode(500, "An error occurred while fetching reservation services.");
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddReservaServicioAsync([FromQuery] ReservaServicioDto reserva)
    {
        try
        {
            var result = await reservaServicioService.AddReservaServicioAsync(reserva);

            return result == 1 ? Ok("Reserva servicio added successfully.") : StatusCode(500, "An error occurred while adding reserva servicio.");
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("An error occurred while adding reserva servicio.", ex);
            return StatusCode(500, "An error occurred while adding reserva servicio.");
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateReservaServicioAsync([FromQuery] ReservaServicioDto reserva)
    {
        try
        {
            var result = await reservaServicioService.UpdateReservaServicioAsync(reserva);

            return result > 0 ? Ok("Reserva servicio updated successfully.") : StatusCode(500, "An error occurred while updating a reserva de servicio.");
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("An error occurred while updating a reserva de servicio.", ex);
            return StatusCode(500, "An error occurred while updating a reserva de servicio.");
        }
    }

    [HttpPut("toggle-state/{id}")]
    public async Task<IActionResult> ToggleEstadoReservaServicioAsync(uint id)
    {
        try
        {
            var result = await reservaServicioService.ToggleEstadoReservaServicioAsync(id);

            return result > 0 ? Ok("Reserva servicio state toggled successfully.") : StatusCode(500, $"An error occurred while toggling reserva servicio state. Reserva servicio with ID {id} not found.");
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("An error occurred while toggling reserva de servicio state.", ex);
            return StatusCode(500, "An error occurred while toggling reserva servicio state.");
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteReservaServicioAsync(uint id)
    {
        try
        {
            var result = await reservaServicioService.DeleteReservaServicioAsync(id);

            return result > 0 ? Ok("Reserva servicio deleted successfully.") : StatusCode(500, $"An error occurred while deleting reserva servicio. Reserva servicio with ID {id} not found.");
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("An error occurred while deleting reserva servicio.", ex);
            return StatusCode(500, "An error occurred while deleting reserva servicio.");
        }
    }
}