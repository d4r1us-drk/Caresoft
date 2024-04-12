using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaServicioController : ControllerBase
    {
        private readonly IReservaServicioService _reservaServicioService;
        private readonly LogHandler<ReservaServicioController> _logHandler = new();

        public ReservaServicioController(IReservaServicioService reservaServicioService)
        {
            _reservaServicioService = reservaServicioService;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ReservaServicioDto>>> GetReservaServiciosListAsync()
        {
            try
            {
                var reservas = await _reservaServicioService.GetReservaServiciosListAsync();

                return Ok(reservas);
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("An error occurred while fetching reservation services.", ex);
                return StatusCode(500, "An error occurred while fetching reservation services.");
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddReservaServicioAsync(
            [FromQuery] string documentoPaciente,
            [FromQuery] string documentoMedico,
            [FromQuery] string servicioCodigo,
            [FromQuery] DateTime fechaReservada,
            [FromQuery] string estado)
        {
            try
            {
                var reserva = new ReservaServicio
                {
                    DocumentoPaciente = documentoPaciente,
                    DocumentoMedico = documentoMedico,
                    ServicioCodigo = servicioCodigo,
                    FechaReservada = fechaReservada,
                    Estado = estado
                };

                var result = await _reservaServicioService.AddReservaServicioAsync(reserva);

                if (result == 1)
                {
                    return Ok("Reserva servicio added successfully.");
                }
                else
                {
                    return StatusCode(500, "An error occurred while adding reserva servicio.");
                }
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("An error occurred while adding reserva servicio.", ex);
                return StatusCode(500, "An error occurred while adding reserva servicio.");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateReservaServicioAsync(
            [FromQuery] uint idReserva,
            [FromQuery] string documentoPaciente,
            [FromQuery] string documentoMedico,
            [FromQuery] string servicioCodigo,
            [FromQuery] DateTime fechaReservada,
            [FromQuery] string estado)
        {
            try
            {
                var reserva = new ReservaServicio
                {
                    IdReserva = idReserva,
                    DocumentoPaciente = documentoPaciente,
                    DocumentoMedico = documentoMedico,
                    ServicioCodigo = servicioCodigo,
                    FechaReservada = fechaReservada,
                    Estado = estado
                };

                var result = await _reservaServicioService.UpdateReservaServicioAsync(reserva);

                if (result > 0)
                {
                    return Ok("Reserva servicio updated successfully.");
                }
                else
                {
                    return StatusCode(500, "An error occurred while updating a reserva de servicio.");
                }
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
                var result = await _reservaServicioService.ToggleEstadoReservaServicioAsync(id);

                if (result > 0)
                {
                    return Ok("Reserva servicio state toggled successfully.");
                }
                else
                {
                    return StatusCode(500, $"An error occurred while toggling reserva servicio state. Reserva servicio with ID {id} not found.");
                }
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
                var result = await _reservaServicioService.DeleteReservaServicioAsync(id);

                if (result > 0)
                {
                    return Ok("Reserva servicio deleted successfully.");
                }
                else
                {
                    return StatusCode(500, $"An error occurred while deleting reserva servicio. Reserva servicio with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the error
                _logHandler.LogFatal("An error occurred while deleting reserva servicio.", ex);
                return StatusCode(500, "An error occurred while deleting reserva servicio.");
            }
        }
    }
}
