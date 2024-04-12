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
        public async Task<ActionResult<List<UsuarioDto>>> GetUsuariosListAsync()
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosListAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUsuarioAsync([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = MapToUsuario(usuarioDto);
                var perfilUsuario = MapToPerfilUsuario(usuarioDto);
                
                var result = await _usuarioService.AddUsuarioAsync(usuario, perfilUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateUsuarioAsync([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = MapToUsuario(usuarioDto);
                var perfilUsuario = MapToPerfilUsuario(usuarioDto);
                
                var result = await _usuarioService.UpdateUsuarioAsync(usuario, perfilUsuario);
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

        private Usuario MapToUsuario(UsuarioDto usuarioDto)
        {
            return new Usuario
            {
                UsuarioCodigo = usuarioDto.UsuarioCodigo,
                UsuarioContra = usuarioDto.UsuarioContra,
                DocumentoUsuario = usuarioDto.Documento,
                // You might need to map more properties depending on your model
            };
        }

        private PerfilUsuario MapToPerfilUsuario(UsuarioDto usuarioDto)
        {
            return new PerfilUsuario
            {
                Documento = usuarioDto.Documento,
                TipoDocumento = usuarioDto.TipoDocumento,
                NumLicenciaMedica = usuarioDto.NumLicenciaMedica,
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Genero = usuarioDto.Genero,
                FechaNacimiento = usuarioDto.FechaNacimiento ?? DateTime.MinValue,
                Telefono = usuarioDto.Telefono,
                Correo = usuarioDto.Correo,
                Direccion = usuarioDto.Direccion,
                Rol = usuarioDto.Rol
            };
        }
    }
}
