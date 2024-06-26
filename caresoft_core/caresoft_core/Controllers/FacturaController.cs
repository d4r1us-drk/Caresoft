using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using caresoft_core.Dto;

namespace caresoft_core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacturaController(IFacturaService facturaService) : ControllerBase
{
    [HttpPost("add")]
    public async Task<ActionResult<int>> AddFacturaAsync([FromQuery] FacturaDto facturaDto)
    {
        try
        {
            var affectedRows = await facturaService.AddFacturaAsync(facturaDto);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<int>> UpdateFacturaAsync([FromQuery] FacturaDto facturaDto)
    {
        try
        {
            var affectedRows = await facturaService.UpdateFacturaAsync(facturaDto);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("delete/{facturaCodigo}")]
    public async Task<ActionResult<int>> DeleteFacturaAsync(string facturaCodigo)
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
    public async Task<ActionResult<List<FacturaDto>?>> GetFacturasAsync()
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
    public async Task<ActionResult<int>> AddFacturaServicioAsync([FromQuery] FacturaServicioDto facturaServicioDto)
    {
        try
        {
            var affectedRows = await facturaService.AddFacturaServicioAsync(facturaServicioDto);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("deleteFacturaServicio/{facturaCodigo}/{servicioCodigo}")]
    public async Task<ActionResult<int>> DeleteFacturaServicioAsync(string facturaCodigo, string servicioCodigo)
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
    public async Task<ActionResult<List<ServicioDto>?>> GetFacturaServiciosAsync(string facturaCodigo)
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
    public async Task<ActionResult<int>> AddFacturaProductoAsync([FromQuery] FacturaProductoDto facturaProductoDto)
    {
        try
        {
            var affectedRows = await facturaService.AddFacturaProductoAsync(facturaProductoDto);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("deleteFacturaProducto/{facturaCodigo}/{idProducto}")]
    public async Task<ActionResult<int>> DeleteFacturaProductoAsync(string facturaCodigo, uint idProducto)
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

    [HttpGet("getFacturaProductos/{facturaCodigo}")]
    public async Task<ActionResult<List<FacturaProductoDto>?>> GetFacturaProductosAsync(string facturaCodigo)
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

    [HttpPost("addFacturaMetodoPago/{facturaCodigo}/{idMetodoPago}")]
    public async Task<ActionResult<int>> AddFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
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

    [HttpDelete("deleteFacturaMetodoPago/{facturaCodigo}/{idMetodoPago}")]
    public async Task<ActionResult<int>> DeleteFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
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

    [HttpGet("getMetodoPagos/{facturaCodigo}")]
    public async Task<ActionResult<List<MetodoPagoDto>?>> GetMetodoPagosAsync(string facturaCodigo)
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