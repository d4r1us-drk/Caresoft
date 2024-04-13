using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicioController(ITipoServicioService tipoServicioService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddTipoServicio([FromBody] TipoServicioDto tipoServicioDto)
        {
            var result = await tipoServicioService.AddTipoServicioAsync(tipoServicioDto);
            return result == 1 ? Ok("Tipo de servicio creado con éxito.") : BadRequest("Error al crear tipo de servicio.");
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoServicioDto>>> GetAllTipoServicios()
        {
            var tipoServicios = await tipoServicioService.GetTipoServiciosAsync();
            return Ok(tipoServicios);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTipoServicio([FromBody] TipoServicioDto tipoServicioDto)
        {
            var result = await tipoServicioService.UpdateTipoServicioAsync(tipoServicioDto);
            return result == 1 ? Ok("Tipo de servicio actualizado con éxito.") : NotFound("Tipo de servicio no encontrado.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoServicio(uint id)
        {
            var result = await tipoServicioService.DeleteTipoServicioAsync(id);
            return result == 1 ? Ok("Tipo de servicio eliminado con éxito.") : NotFound("Tipo de servicio no encontrado.");
        }
    }
}
