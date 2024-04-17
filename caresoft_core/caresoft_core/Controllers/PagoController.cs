using caresoft_core.Dto;
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
    public async Task<ActionResult<IEnumerable<PagoDto>>> GetPagos()
    {
        try
        {
            var pagos = await _pagoService.GetPagosAsync();
            return Ok(pagos.Select(e => PagoDto.FromModel(e)));
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("get/{idPago}")]
    public async Task<ActionResult<PagoDto?>> GetPagoById(uint idPago)
    {
        try
        {
            var pago = await _pagoService.GetPagoByIdAsync(idPago);
            if (pago == null)
            {
                return Ok(null);
            } else
            {
                return Ok(PagoDto.FromModel(pago));

            }
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("add")]
    public async Task<ActionResult> CreatePago(PagoDto pago)
    {
        try
        {
            await _pagoService.CreatePagoAsync(Pago.FromDto( pago));
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex.InnerException.Message.Contains("pagar"))
            {
                return StatusCode(400, ex.InnerException.Message);
            }

            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdatePago(PagoDto pago)
    {
        try
        {
            await _pagoService.UpdatePagoAsync(Pago.FromDto(pago));
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