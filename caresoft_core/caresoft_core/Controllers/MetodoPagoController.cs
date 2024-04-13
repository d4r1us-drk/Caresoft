using Microsoft.AspNetCore.Mvc;
using caresoft_core.Services.Interfaces;
using caresoft_core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        private readonly IMetodoPagoService _metodoPagoService;

        public MetodoPagoController(IMetodoPagoService metodoPagoService)
        {
            _metodoPagoService = metodoPagoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMetodoPago([FromBody] MetodoPagoDto metodoPagoDto)
        {
            int result = await _metodoPagoService.AddMetodoPagoAsync(metodoPagoDto);
            if (result == 1)
                return Ok("MetodoPago added successfully.");
            else
                return BadRequest("Failed to add MetodoPago.");
        }

        [HttpGet]
        public async Task<ActionResult<List<MetodoPagoDto>>> GetAllMetodosPago()
        {
            var metodoPagos = await _metodoPagoService.GetMetodosPagoAsync();
            return Ok(metodoPagos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMetodoPago([FromBody] MetodoPagoDto metodoPagoDto)
        {
            int result = await _metodoPagoService.UpdateMetodoPagoAsync(metodoPagoDto);
            if (result == 1)
                return Ok("MetodoPago updated successfully.");
            else
                return NotFound("MetodoPago not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodoPago(uint id)
        {
            int result = await _metodoPagoService.DeleteMetodoPagoAsync(id);
            if (result == 1)
                return Ok("MetodoPago deleted successfully.");
            else
                return NotFound("MetodoPago not found.");
        }
    }
}
