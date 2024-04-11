using caresoft_core.Models;
using caresoft_core.Services;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDto>>> GetUsuariosListAsync(string? documento, string? genero, DateTime? fechaNacimiento, string? rol)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosListAsync(documento, genero, fechaNacimiento, rol);

                var usuariosDto = usuarios.Select(usuario => new UsuarioDto
                {
                    UsuarioCodigo = usuario.UsuarioCodigo,
                    UsuarioContra = usuario.UsuarioContra,
                    Documento = usuario.Documento,
                    TipoDocumento = usuario.TipoDocumento,
                    NumLicenciaMedica = usuario.NumLicenciaMedica.GetValueOrDefault(),
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Genero = usuario.Genero,
                    FechaNacimiento = usuario.FechaNacimiento,
                    Telefono = usuario.Telefono,
                    Correo = usuario.Correo,
                    Direccion = usuario.Direccion,
                    Rol = usuario.Rol
                }).ToList();

                return Ok(usuariosDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("addUsuarioPaciente")]
        public async Task<IActionResult> AddUsuarioPacienteAsync(string usuarioCodigo, string usuarioContra, string documento, string tipoDocumento, string nombre, string apellido, string genero, DateTime fechaNacimiento, string telefono, string correo, string direccion)
        {
            try
            {
                var usuario = new Usuario
                {
                    UsuarioCodigo = usuarioCodigo,
                    DocumentoUsuario = documento,
                    UsuarioContra = usuarioContra
                };

                var perfilUsuario = new PerfilUsuario
                {
                    Documento = documento,
                    TipoDocumento = tipoDocumento,
                    NumLicenciaMedica = null,
                    Nombre = nombre,
                    Apellido = apellido,
                    Genero = genero,
                    FechaNacimiento = fechaNacimiento,
                    Telefono = telefono,
                    Correo = correo,
                    Direccion = direccion,
                    Rol = "P"
                };

                var result = await _usuarioService.AddUsuarioPacienteAsync(usuario, perfilUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpPost("addUsuarioPersonal")]
        public async Task<ActionResult<int>> AddUsuarioPersonalAsync(string usuarioCodigo, string documentoUsuario, string usuarioContra, string documento, string tipoDocumento, uint? numLicenciaMedica, string nombre, string apellido, string genero, DateTime fechaNacimiento, string telefono, string correo, string direccion, string rol)
        {
            try
            {
                var usuario = new Usuario
                {
                    UsuarioCodigo = usuarioCodigo,
                    DocumentoUsuario = documentoUsuario,
                    UsuarioContra = usuarioContra
                };

                var perfilUsuario = new PerfilUsuario
                {
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

                var result = await _usuarioService.AddUsuarioPersonalAsync(usuario, perfilUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpPost("addUsuarioMedico")]
        public async Task<ActionResult<int>> AddUsuarioMedicoAsync(string usuarioCodigo, string documentoUsuario, string usuarioContra, string documento, string tipoDocumento, uint? numLicenciaMedica, string nombre, string apellido, string genero, DateTime fechaNacimiento, string telefono, string correo, string direccion, string rol)
        {
            try
            {
                var usuario = new Usuario
                {
                    UsuarioCodigo = usuarioCodigo,
                    DocumentoUsuario = documentoUsuario,
                    UsuarioContra = usuarioContra
                };

                var perfilUsuario = new PerfilUsuario
                {
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

                var result = await _usuarioService.AddUsuarioMedicoAsync(usuario, perfilUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateUsuario")]
        public async Task<ActionResult<int>> UpdateUsuarioAsync(string usuarioCodigo, string usuarioContra, string documento, string tipoDocumento, string nombre, string apellido, string genero, DateTime fechaNacimiento, string telefono, string correo, string direccion)
        {
            try
            {
                var usuario = new Usuario
                {
                    UsuarioCodigo = usuarioCodigo,
                    UsuarioContra = usuarioContra
                };

                var perfilUsuario = new PerfilUsuario
                {
                    Documento = documento,
                    TipoDocumento = tipoDocumento,
                    Nombre = nombre,
                    Apellido = apellido,
                    Genero = genero,
                    FechaNacimiento = fechaNacimiento,
                    Telefono = telefono,
                    Correo = correo,
                    Direccion = direccion
                };

                var result = await _usuarioService.UpdateUsuarioAsync(usuario, perfilUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteUsuario")]
        public async Task<ActionResult<int>> DeleteUsuarioAsync(string codigoOdocumento)
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
