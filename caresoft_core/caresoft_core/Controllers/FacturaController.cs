using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacturaController(IFacturaService facturaService) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddFacturaAsync([FromQuery] Factura factura)
    {
        try
        {
            var affectedRows = await facturaService.AddFacturaAsync(factura);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateFacturaAsync([FromQuery] Factura factura)
    {
        try
        {
            var affectedRows = await facturaService.UpdateFacturaAsync(factura);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("delete/{facturaCodigo}")]
    public async Task<IActionResult> DeleteFacturaAsync(string facturaCodigo)
    {
        try
        {
            var affectedRows = await facturaService.DeleteFacturaAsync(facturaCodigo);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetFacturasAsync()
    {
        try
        {
            var facturas = await facturaService.GetFacturasAsync();
            return Ok(facturas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("addFacturaServicio")]
    public async Task<IActionResult> AddFacturaServicioAsync([FromQuery] FacturaServicio facturaServicio)
    {
        try
        {
            var affectedRows = await facturaService.AddFacturaServicioAsync(facturaServicio);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("deleteFacturaServicio/{facturaCodigo}/{servicioCodigo}")]
    public async Task<IActionResult> DeleteFacturaServicioAsync(string facturaCodigo, string servicioCodigo)
    {
        try
        {
            var affectedRows = await facturaService.DeleteFacturaServicioAsync(facturaCodigo, servicioCodigo);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("getFacturaServicios/{facturaCodigo}")]
    public async Task<IActionResult> GetFacturaServiciosAsync(string facturaCodigo)
    {
        try
        {
            var facturaServicios = await facturaService.GetFacturaServiciosAsync(facturaCodigo);
            return Ok(facturaServicios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("addFacturaProducto")]
    public async Task<IActionResult> AddFacturaProductoAsync([FromQuery] FacturaProducto facturaProducto)
    {
        try
        {
            var affectedRows = await facturaService.AddFacturaProductoAsync(facturaProducto);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("deleteFacturaProducto")]
    public async Task<IActionResult> DeleteFacturaProductoAsync([FromQuery] string facturaCodigo, [FromQuery] uint idProducto)
    {
        try
        {
            var affectedRows = await facturaService.DeleteFacturaProductoAsync(facturaCodigo, idProducto);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("getFacturaProductos")]
    public async Task<IActionResult> GetFacturaProductosAsync([FromQuery] string facturaCodigo)
    {
        try
        {
            var facturaProductos = await facturaService.GetFacturaProductosAsync(facturaCodigo);
            return Ok(facturaProductos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("addFacturaMetodoPago")]
    public async Task<IActionResult> AddFacturaMetodoPagoAsync([FromQuery] string facturaCodigo, [FromQuery] uint idMetodoPago)
    {
        try
        {
            var affectedRows = await facturaService.AddFacturaMetodoPagoAsync(facturaCodigo, idMetodoPago);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("deleteFacturaMetodoPago")]
    public async Task<IActionResult> DeleteFacturaMetodoPagoAsync([FromQuery] string facturaCodigo, [FromQuery] uint idMetodoPago)
    {
        try
        {
            var affectedRows = await facturaService.DeleteFacturaMetodoPagoAsync(facturaCodigo, idMetodoPago);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("getMetodoPagos")]
    public async Task<IActionResult> GetMetodoPagosAsync([FromQuery] string facturaCodigo)
    {
        try
        {
            var metodoPagos = await facturaService.GetMetodoPagosAsync(facturaCodigo);
            return Ok(metodoPagos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}