using caresoft_integration.Dto;
using caresoft_integration.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalService _sucursalService;

        public SucursalController(ISucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSucursal([FromBody] SucursalDto sucursalDto)
        {
            var result = await _sucursalService.CreateSucursalAsync(sucursalDto);
            return result == 1 ? Ok("Sucursal created successfully.") : BadRequest("Failed to create sucursal.");
        }

        [HttpGet]
        public async Task<ActionResult<List<SucursalDto>>> GetAllSucursales()
        {
            var sucursales = await _sucursalService.GetSucursalesAsync();
            return Ok(sucursales);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSucursal([FromBody] SucursalDto sucursalDto)
        {
            var result = await _sucursalService.UpdateSucursalAsync(sucursalDto);
            return result == 1 ? Ok("Sucursal updated successfully.") : NotFound("Sucursal not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(uint id)
        {
            var result = await _sucursalService.DeleteSucursalAsync(id);
            return result == 1 ? Ok("Sucursal deleted successfully.") : NotFound("Sucursal not found.");
        }
    }
}
