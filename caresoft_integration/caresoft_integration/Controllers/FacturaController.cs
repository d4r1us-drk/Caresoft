using Microsoft.AspNetCore.Mvc;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;
using caresoft_integration.Models;

namespace caresoft_integration.Controllers
{
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
        public async Task<ActionResult<int>> AddFacturaAsync([FromBody] FacturaDto facturaDto)
        {
            var result = await _facturaService.AddFacturaAsync(facturaDto);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateFacturaAsync([FromBody] FacturaDto facturaDto)
        {
            var result = await _facturaService.UpdateFacturaAsync(facturaDto);
            return Ok(result);
        }

        [HttpDelete("delete/{facturaCodigo}")]
        public async Task<ActionResult<int>> DeleteFacturaAsync(string facturaCodigo)
        {
            var result = await _facturaService.DeleteFacturaAsync(facturaCodigo);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<FacturaDto>>> GetFacturasAsync()
        {
            var result = await _facturaService.GetFacturasAsync();
            return Ok(result);
        }

        [HttpPost("addFacturaServicio")]
        public async Task<ActionResult<int>> AddFacturaServicioAsync([FromBody] FacturaServicioDto facturaServicioDto)
        {
            var result = await _facturaService.AddFacturaServicioAsync(facturaServicioDto);
            return Ok(result);
        }

        [HttpDelete("deleteFacturaServicio/{facturaCodigo}/{servicioCodigo}")]
        public async Task<ActionResult<int>> DeleteFacturaServicioAsync(string facturaCodigo, string servicioCodigo)
        {
            var result = await _facturaService.DeleteFacturaServicioAsync(facturaCodigo, servicioCodigo);
            return Ok(result);
        }

        [HttpGet("getFacturaServicios/{facturaCodigo}")]
        public async Task<ActionResult<IEnumerable<FacturaServicioDto>>> GetFacturaServiciosAsync(string facturaCodigo)
        {
            var result = await _facturaService.GetFacturaServiciosAsync(facturaCodigo);
            return Ok(result);
        }

        [HttpPost("addFacturaProducto")]
        public async Task<ActionResult<int>> AddFacturaProductoAsync([FromBody] FacturaProductoDto facturaProductoDto)
        {
            var result = await _facturaService.AddFacturaProductoAsync(facturaProductoDto);
            return Ok(result);
        }

        [HttpDelete("deleteFacturaProducto/{facturaCodigo}/{idProducto}")]
        public async Task<ActionResult<int>> DeleteFacturaProductoAsync(string facturaCodigo, uint idProducto)
        {
            var result = await _facturaService.DeleteFacturaProductoAsync(facturaCodigo, idProducto);
            return Ok(result);
        }

        [HttpGet("getFacturaProductos/{facturaCodigo}")]
        public async Task<ActionResult<IEnumerable<FacturaProductoDto>>> GetFacturaProductosAsync(string facturaCodigo)
        {
            var result = await _facturaService.GetFacturaProductosAsync(facturaCodigo);
            return Ok(result);
        }

        [HttpPost("addMetodoPago/{facturaCodigo}/{idMetodoPago}")]
        public async Task<ActionResult<int>> AddFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
        {
            var result = await _facturaService.AddFacturaMetodoPagoAsync(facturaCodigo, idMetodoPago);
            return Ok(result);
        }

        [HttpDelete("deleteMetodoPago/{facturaCodigo}/{idMetodoPago}")]
        public async Task<ActionResult<int>> DeleteFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
        {
            var result = await _facturaService.DeleteFacturaMetodoPagoAsync(facturaCodigo, idMetodoPago);
            return Ok(result);
        }

        [HttpGet("getMetodoPagos/{facturaCodigo}")]
        public async Task<ActionResult<IEnumerable<MetodoPago>>> GetMetodoPagosAsync(string facturaCodigo)
        {
            var result = await _facturaService.GetMetodoPagosAsync(facturaCodigo);
            return Ok(result);
        }
    }
}
