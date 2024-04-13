using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultaController(IConsultaService consultaService) : ControllerBase
{
    private readonly LogHandler<ConsultaController> _logHandler = new();

    [HttpPost("add")]
    public async Task<IActionResult> CrearConsulta([FromQuery] ConsultaDto consulta)
    {
        try
        {
            var result = await consultaService.AddConsultaAsync(consulta);
            return Ok(result);

        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al crear consulta", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear consulta");
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> ActualizarConsulta([FromQuery]ConsultaDto consultaDto)
    {
        try
        {
            var result = await consultaService.UpdateConsultaAsync(consultaDto);
            return Ok(result);

        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al actualizar consulta", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar consulta");
        }
    }

    [HttpDelete("delete/{consultaCodigo}")]
    public async Task<IActionResult> EliminarConsulta(string consultaCodigo)
    {
        try
        {
            var result = await consultaService.RemoveConsultaAsync(consultaCodigo);
            return Ok(result);
        }
        catch (Exception ex)
        {

            _logHandler.LogFatal("Error al eliminar consulta", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar consulta");
        }
    }

    [HttpGet("get")]
    public async Task<IActionResult> ListarConsultas()
    {
        try
        {
            var result = await consultaService.GetConsultasAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al listar consultas", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al listar consultas");
        }
    }

    [HttpPost("addServicio/{consultaCodigo}/{servicioCodigo}")]
    public async Task<IActionResult> RelacionarServicio(string consultaCodigo, string servicioCodigo)
    {
        try
        {
            var result = await consultaService.AddConsultaServicioAsync(consultaCodigo, servicioCodigo);
            return Ok(result);

        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al relacionar servicio", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al relacionar servicio");
        }
    }

    [HttpDelete("deleteServicio/{consultaCodigo}/{servicioCodigo}")]
    public async Task<IActionResult> DesrelacionarServicio(string consultaCodigo, string servicioCodigo)
    {
        try
        {
            var result = await consultaService.RemoveConsultaServicioAsync(consultaCodigo, servicioCodigo);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al desrelacionar servicio", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al desrelacionar servicio");
        }
    }

    [HttpGet("getServicios/{consultaCodigo}/")]
    public async Task<IActionResult> ListarServicios(string consultaCodigo)
    {
        try
        {
            var result = await consultaService.GetConsultaServiciosAsync(consultaCodigo);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al listar servicios", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al listar servicios");
        }
    }

    [HttpPost("addProducto/{consultaCodigo}/{idProducto}/{cantidad}")]
    public async Task<IActionResult> RelacionarProducto(string consultaCodigo, uint idProducto, int cantidad)
    {
        try
        {
            var result = await consultaService.AddConsultaProductoAsync(consultaCodigo, idProducto, cantidad);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al relacionar producto", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al relacionar producto");
        }
    }

    [HttpDelete("deleteProducto/{consultaCodigo}/{idProducto}/{cantidad}")]
    public async Task<IActionResult> DesrelacionarProducto(string consultaCodigo, uint idProducto, int cantidad)
    {
        try
        {
            var result = await consultaService.RemoveConsultaProductoAsync(consultaCodigo, idProducto, cantidad);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al desrelacionar producto", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al desrelacionar producto");
        }
    }

    [HttpGet("getProductos/{consultaCodigo}")]
    public async Task<IActionResult> ListarProductos(string consultaCodigo)
    {
        try
        {
            var result = await consultaService.GetConsultaProductosAsync(consultaCodigo);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al listar productos", ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al listar productos");
        }
    }
}