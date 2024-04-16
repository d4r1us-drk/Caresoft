using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_integration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PagoController(IPagoService pagoService) : ControllerBase
{
    private readonly IPagoService _pagoService = pagoService ?? throw new ArgumentNullException(nameof(pagoService));

    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<Pago>>> GetPagos()
    {
        try
        {
            var pagos = await _pagoService.GetPagosAsync();
            return Ok(pagos);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("get/{idPago}")]
    public async Task<ActionResult<Pago>> GetPagoById(uint idPago)
    {
        try
        {
            var pago = await _pagoService.GetPagoByIdAsync(idPago);
            return Ok(pago);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("add")]
    public async Task<ActionResult<Pago>> CreatePago(Pago pago)
    {
        try
        {
            await _pagoService.CreatePagoAsync(pago);
            return CreatedAtAction(nameof(GetPagoById), new { idPago = pago.IdPago }, pago);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdatePago(Pago pago)
    {
        try
        {
            await _pagoService.UpdatePagoAsync(pago);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("delete/{idPago}")]
    public async Task<IActionResult> DeletePago(uint idPago)
    {
        try
        {
            var result = await _pagoService.DeletePagoAsync(idPago);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}