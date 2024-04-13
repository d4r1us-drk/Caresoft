using caresoft_core.Models;
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

    [HttpGet("list")]
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
    public async Task<ActionResult> AddReservaServicioAsync([FromQuery] ReservaServicioDto reserva)
    {
        try
        {
            var result = await reservaServicioService.AddReservaServicioAsync(reserva);

            if (result == 1)
                return Ok("Reserva servicio added successfully.");

            return StatusCode(500, "An error occurred while adding reserva servicio.");
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("An error occurred while adding reserva servicio.", ex);
            return StatusCode(500, "An error occurred while adding reserva servicio.");
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateReservaServicioAsync([FromQuery] ReservaServicioDto reserva)
    {
        try
        {
            var result = await reservaServicioService.UpdateReservaServicioAsync(reserva);

            if (result > 0)
                return Ok("Reserva servicio updated successfully.");

            return StatusCode(500, "An error occurred while updating a reserva de servicio.");
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("An error occurred while updating a reserva de servicio.", ex);
            return StatusCode(500, "An error occurred while updating a reserva de servicio.");
        }
    }

    [HttpPut("toggle-state/{id}")]
    public async Task<ActionResult> ToggleEstadoReservaServicioAsync(uint id)
    {
        try
        {
            var result = await reservaServicioService.ToggleEstadoReservaServicioAsync(id);

            if (result > 0)
                return Ok("Reserva servicio state toggled successfully.");

            return StatusCode(500, $"An error occurred while toggling reserva servicio state. Reserva servicio with ID {id} not found.");
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("An error occurred while toggling reserva de servicio state.", ex);
            return StatusCode(500, "An error occurred while toggling reserva servicio state.");
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteReservaServicioAsync(uint id)
    {
        try
        {
            var result = await reservaServicioService.DeleteReservaServicioAsync(id);

            if (result > 0)
                return Ok("Reserva servicio deleted successfully.");

            return StatusCode(500, $"An error occurred while deleting reserva servicio. Reserva servicio with ID {id} not found.");
        }
        catch (Exception ex)
        {
            // Log the error
            _logHandler.LogFatal("An error occurred while deleting reserva servicio.", ex);
            return StatusCode(500, "An error occurred while deleting reserva servicio.");
        }
    }
}