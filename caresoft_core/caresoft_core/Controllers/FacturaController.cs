using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacturaController : ControllerBase
{
    private readonly IFacturaService _facturaService;

    public FacturaController(IFacturaService facturaService)
    {
        _facturaService = facturaService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddFacturaAsync([FromQuery] string facturaCodigo, [FromQuery] DateTime fecha, [FromQuery] string documentoCajero)
    {
        try
        {
            Factura factura = new Factura
            {
                FacturaCodigo = facturaCodigo,
                Fecha = fecha,
                DocumentoCajero = documentoCajero
            };

            int affectedRows = await _facturaService.AddFacturaAsync(factura);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateFacturaAsync([FromQuery] string facturaCodigo, [FromQuery] DateTime fecha, [FromQuery] string documentoCajero)
    {
        try
        {
            Factura factura = new Factura
            {
                FacturaCodigo = facturaCodigo,
                Fecha = fecha,
                DocumentoCajero = documentoCajero
            };

            int affectedRows = await _facturaService.UpdateFacturaAsync(factura);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteFacturaAsync([FromQuery] string facturaCodigo)
    {
        try
        {
            int affectedRows = await _facturaService.DeleteFacturaAsync(facturaCodigo);
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
            IEnumerable<Factura> facturas = await _facturaService.GetFacturasAsync();
            return Ok(facturas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("addFacturaServicio")]
    public async Task<IActionResult> AddFacturaServicioAsync([FromQuery] string facturaCodigo, [FromQuery] string servicioCodigo)
    {
        try
        {
            FacturaServicio facturaServicio = new FacturaServicio
            {
                FacturaCodigo = facturaCodigo,
                ServicioCodigo = servicioCodigo
            };

            int affectedRows = await _facturaService.AddFacturaServicioAsync(facturaServicio);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("deleteFacturaServicio")]
    public async Task<IActionResult> DeleteFacturaServicioAsync([FromQuery] string facturaCodigo, [FromQuery] string servicioCodigo)
    {
        try
        {
            int affectedRows = await _facturaService.DeleteFacturaServicioAsync(facturaCodigo, servicioCodigo);
            return Ok(affectedRows);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("getFacturaServicios")]
    public async Task<IActionResult> GetFacturaServiciosAsync([FromQuery] string facturaCodigo)
    {
        try
        {
            IEnumerable<FacturaServicio> facturaServicios = await _facturaService.GetFacturaServiciosAsync(facturaCodigo);
            return Ok(facturaServicios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("addFacturaProducto")]
    public async Task<IActionResult> AddFacturaProductoAsync([FromQuery] string facturaCodigo, [FromQuery] uint idProducto)
    {
        try
        {
            FacturaProducto facturaProducto = new FacturaProducto
            {
                FacturaCodigo = facturaCodigo,
                IdProducto = idProducto
            };

            int affectedRows = await _facturaService.AddFacturaProductoAsync(facturaProducto);
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
            int affectedRows = await _facturaService.DeleteFacturaProductoAsync(facturaCodigo, idProducto);
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
            IEnumerable<FacturaProducto> facturaProductos = await _facturaService.GetFacturaProductosAsync(facturaCodigo);
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
            int affectedRows = await _facturaService.AddFacturaMetodoPagoAsync(facturaCodigo, idMetodoPago);
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
            int affectedRows = await _facturaService.DeleteFacturaMetodoPagoAsync(facturaCodigo, idMetodoPago);
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
            IEnumerable<MetodoPago> metodoPagos = await _facturaService.GetMetodoPagosAsync(facturaCodigo);
            return Ok(metodoPagos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}