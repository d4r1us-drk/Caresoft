using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;
        private readonly LogHandler<ConsultaController> _logHandler = new();
        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearConsulta([FromQuery] ConsultaDto consulta)
        {
            try
            {

                int result = await _consultaService.CrearConsulta(consulta);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Error al crear consulta", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear consulta");
            }
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarConsulta([FromQuery]ConsultaDto consultaDto)
        {
            try
            {
                int result = await _consultaService.ActualizarConsulta(consultaDto);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Error al actualizar consulta", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar consulta");
            }
        }

        [HttpDelete("{consultaCodigo}")]
        public async Task<IActionResult> EliminarConsulta(string consultaCodigo)
        {
            try
            {
                int result = await _consultaService.EliminarConsulta(consultaCodigo);
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logHandler.LogFatal("Error al eliminar consulta", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar consulta");
            }
        }

        [HttpPost("{consultaCodigo}/servicio/{servicioCodigo}")]
        public async Task<IActionResult> RelacionarServicio(string consultaCodigo, string servicioCodigo)
        {
            try
            {
                int result = await _consultaService.RelacionarServicio(consultaCodigo, servicioCodigo);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Error al relacionar servicio", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al relacionar servicio");
            }
        }

        [HttpDelete("{consultaCodigo}/servicio/{servicioCodigo}")]
        public async Task<IActionResult> DesrelacionarServicio(string consultaCodigo, string servicioCodigo)
        {
            try
            {
                int result = await _consultaService.DesrelacionarServicio(consultaCodigo, servicioCodigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Error al desrelacionar servicio", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al desrelacionar servicio");
            }
        }

        [HttpGet("{consultaCodigo}/servicios")]
        public async Task<IActionResult> ListarServicios(string consultaCodigo)
        {
            try
            {
                List<Servicio> result = await _consultaService.ListarServicios(consultaCodigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Error al listar servicios", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al listar servicios");
            }
        }

        [HttpPost("{consultaCodigo}/producto/{idProducto}/{cantidad}")]
        public async Task<IActionResult> RelacionarProducto(string consultaCodigo, uint idProducto, int cantidad)
        {
            try
            {
                int result = await _consultaService.RelacionarProducto(consultaCodigo, idProducto, cantidad);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Error al relacionar producto", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al relacionar producto");
            }
        }

        [HttpDelete("{consultaCodigo}/producto/{idProducto}/{cantidad}")]
        public async Task<IActionResult> DesrelacionarProducto(string consultaCodigo, uint idProducto, int cantidad)
        {
            try
            {
                int result = await _consultaService.DesrelacionarProducto(consultaCodigo, idProducto, cantidad);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al desrelacionar producto", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al desrelacionar producto");
            }
        }

        [HttpGet("{consultaCodigo}/productos")]
        public async Task<IActionResult> ListarProductos(string consultaCodigo)
        {
            try
            {
                List<Producto> result = await _consultaService.ListarProductos(consultaCodigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Error al listar productos", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al listar productos");
            }

        }
    }
}
