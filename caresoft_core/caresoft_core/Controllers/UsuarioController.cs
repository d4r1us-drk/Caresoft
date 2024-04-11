using caresoft_core.Models;
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
        public async Task<IActionResult> AddUsuarioAsync(
            [FromQuery] string usuarioCodigo,
            [FromQuery] string usuarioContra,
            [FromQuery] string documento,
            [FromQuery] string tipoDocumento,
            [FromQuery] uint? numLicenciaMedica,
            [FromQuery] string nombre,
            [FromQuery] string apellido,
            [FromQuery] string genero,
            [FromQuery] DateTime fechaNacimiento,
            [FromQuery] string telefono,
            [FromQuery] string correo,
            [FromQuery] string direccion,
            [FromQuery] string rol = "P")
        {
            try
            {
                var usuario = new UsuarioDto
                {
                    UsuarioCodigo = usuarioCodigo,
                    UsuarioContra = usuarioContra,
                    Documento = documento,
                    TipoDocumento = tipoDocumento,
                    NumLicenciaMedica = rol == "M" || rol == "E" ? numLicenciaMedica : null,
                    Nombre = nombre,
                    Apellido = apellido,
                    Genero = genero,
                    FechaNacimiento = fechaNacimiento,
                    Telefono = telefono,
                    Correo = correo,
                    Direccion = direccion,
                    Rol = rol,
                };

                var result = await _usuarioService.AddUsuarioAsync(usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateUsuarioAsync(
            [FromQuery] string? usuarioCodigo = null,
            [FromQuery] string? usuarioContra = null,
            [FromQuery] string? documento = null,
            [FromQuery] string? tipoDocumento = null,
            [FromQuery] uint? numLicenciaMedica = null,
            [FromQuery] string? nombre = null,
            [FromQuery] string? apellido = null,
            [FromQuery] string? genero = null,
            [FromQuery] DateTime? fechaNacimiento = null,
            [FromQuery] string? telefono = null,
            [FromQuery] string? correo = null,
            [FromQuery] string? direccion = null,
            [FromQuery] string? rol = null)
        {
            try
            {
                var usuario = new UsuarioDto
                {
                    UsuarioCodigo = usuarioCodigo,
                    UsuarioContra = usuarioContra,
                    Documento = documento,
                    TipoDocumento = tipoDocumento,
                    NumLicenciaMedica = numLicenciaMedica,
                    Nombre = nombre,
                    Apellido = apellido,
                    Genero = genero,
                    FechaNacimiento = fechaNacimiento,
                    Telefono = telefono,
                    Correo = correo,
                    Direccion = direccion,
                    Rol = rol
                };

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
