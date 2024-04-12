using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<UsuarioDto>>> GetUsuariosListAsync(
            [FromQuery] string? usuarioCodigo,
            [FromQuery] string? documento,
            [FromQuery] string? genero,
            [FromQuery] DateTime? fechaNacimiento,
            [FromQuery] string? rol)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosListAsync(usuarioCodigo, documento, genero, fechaNacimiento, rol);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUsuarioAsync(UsuarioDto usuarioDto)
        {
            try
            {
                usuarioDto.NumLicenciaMedica = usuarioDto.Rol == "M" || usuarioDto.Rol == "E" ? usuarioDto.NumLicenciaMedica : null;
                var result = await _usuarioService.AddUsuarioAsync(usuarioDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateUsuarioAsync(UsuarioDto usuario)

        {
            try
            {
                var result = await _usuarioService.UpdateUsuarioAsync(usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<int>> DeleteUsuarioAsync([FromQuery] string codigoOdocumento)
        {
            try
            {
                var result = await _usuarioService.DeleteUsuarioAsync(codigoOdocumento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
