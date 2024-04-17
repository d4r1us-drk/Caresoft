using caresoft_integration.Dto;
using caresoft_integration.Services;
using caresoft_integration.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_integration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaServicioController : ControllerBase
    {
        private readonly IReservaServicioService _reservaServicioService;

        public ReservaServicioController(IReservaServicioService reservaServicioService)
        {
            _reservaServicioService = reservaServicioService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<ReservaServicioDto>>> GetReservaServiciosListAsync()
        {
            try
            {
                var reservaServicios = await _reservaServicioService.GetReservaServiciosListAsync();
                return Ok(reservaServicios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddReservaServicioAsync([FromBody] ReservaServicioDto reservaServicioDto)
        {
            try
            {
                var result = await _reservaServicioService.AddReservaServicioAsync(reservaServicioDto);
                if (result == 1)
                {
                    return Ok("Reserva servicio added successfully.");
                }
                else
                {
                    return BadRequest("Failed to add reserva servicio.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateReservaServicioAsync([FromBody] ReservaServicioDto reservaServicioDto)
        {
            try
            {
                var result = await _reservaServicioService.UpdateReservaServicioAsync(reservaServicioDto);
                if (result == 1)
                {
                    return Ok("Reserva servicio updated successfully.");
                }
                else
                {
                    return BadRequest("Failed to update reserva servicio.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("toggle-state/{id}")]
        public async Task<IActionResult> ToggleEstadoReservaServicioAsync(int id)
        {
            try
            {
                var result = await _reservaServicioService.ToggleEstadoReservaServicioAsync(id);
                if (result == 1)
                {
                    return Ok("Reserva servicio state toggled successfully.");
                }
                else
                {
                    return NotFound($"Reserva servicio with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteReservaServicioAsync(int idReserva)
        {
            try
            {
                var result = await _reservaServicioService.DeleteReservaServicioAsync(idReserva);
                if (result == 1)
                {
                    return Ok("Reserva servicio state toggled successfully.");
                }
                else
                {
                    return NotFound($"Reserva servicio with ID {idReserva} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}