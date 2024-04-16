using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

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
    public async Task<ActionResult<Pago?>> GetPagoById(uint idPago)
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
    public async Task<ActionResult> CreatePago(Pago pago)
    {
        try
        {
            await _pagoService.CreatePagoAsync(pago);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdatePago(Pago pago)
    {
        try
        {
            await _pagoService.UpdatePagoAsync(pago);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("delete/{idPago}")]
    public async Task<ActionResult> DeletePago(uint idPago)
    {
        try
        {
            var result = await _pagoService.DeletePagoAsync(idPago);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}