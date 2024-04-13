using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController(ISalaService salaService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateSala([FromBody] SalaDto salaDto)
        {
            int result = await salaService.CreateSalaAsync(salaDto);
            if (result == 1)
                return Ok("Sala created successfully.");
            return BadRequest("Failed to create sala.");
        }

        [HttpGet]
        public async Task<ActionResult<List<SalaDto>>> GetAllSalas()
        {
            var salas = await salaService.GetAllSalasAsync();
            return Ok(salas);
        }

        [HttpPut("{numSala}")]
        public async Task<IActionResult> UpdateSalaEstado(uint numSala)
        {
            int result = await salaService.UpdateSalaEstadoAsync(numSala);
            if (result == 1)
                return Ok("Sala estado updated successfully.");
            return NotFound("Sala not found.");
        }

        [HttpDelete("{numSala}")]
        public async Task<IActionResult> DeleteSala(uint numSala)
        {
            int result = await salaService.DeleteSalaAsync(numSala);
            if (result == 1)
                return Ok("Sala deleted successfully.");
            return NotFound("Sala not found.");
        }
    }
}
