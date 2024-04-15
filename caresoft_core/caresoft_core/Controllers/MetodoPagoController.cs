using Microsoft.AspNetCore.Mvc;
using caresoft_core.Services.Interfaces;
using caresoft_core.Dto;

namespace caresoft_core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MetodoPagoController(IMetodoPagoService metodoPagoService) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddMetodoPago([FromQuery] MetodoPagoDto metodoPagoDto)
    {
        var result = await metodoPagoService.AddMetodoPagoAsync(metodoPagoDto);
        if (result == 1)
            return Ok("MetodoPago added successfully.");
        return BadRequest("Failed to add MetodoPago.");
    }

    [HttpGet("get")]
    public async Task<ActionResult<List<MetodoPagoDto>?>> GetAllMetodosPago()
    {
        var metodoPagos = await metodoPagoService.GetMetodosPagoAsync();
        return Ok(metodoPagos);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateMetodoPago([FromQuery] MetodoPagoDto metodoPagoDto)
    {
        var result = await metodoPagoService.UpdateMetodoPagoAsync(metodoPagoDto);
        if (result == 1)
            return Ok("MetodoPago updated successfully.");
        return NotFound("MetodoPago not found.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteMetodoPago(uint id)
    {
        var result = await metodoPagoService.DeleteMetodoPagoAsync(id);
        if (result == 1)
            return Ok("MetodoPago deleted successfully.");
        return NotFound("MetodoPago not found.");
    }
}