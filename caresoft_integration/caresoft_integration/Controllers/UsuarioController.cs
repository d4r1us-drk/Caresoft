using Microsoft.AspNetCore.Mvc;
using caresoft_integration.Dto;
using caresoft_integration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_integration.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<UsuarioDto>>> GetAllUsuarios()
        {
            return Ok(await _usuarioService.GetUsuariosListAsync());
        }

        [HttpGet("{codigoOdocumento}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(string codigoOdocumento)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(codigoOdocumento);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddUsuario([FromBody] UsuarioDto usuarioDto)
        {
            var resultado = await _usuarioService.AddUsuarioAsync(usuarioDto);
            if (resultado == 1)
            {
                return CreatedAtAction(nameof(GetUsuario), new { codigoOdocumento = usuarioDto.UsuarioCodigo }, usuarioDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateUsuario([FromBody] UsuarioDto usuarioDto)
        {
            var resultado = await _usuarioService.UpdateUsuarioAsync(usuarioDto);
            if (resultado == 1)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{codigoOdocumento}")]
        public async Task<ActionResult> DeleteUsuario(string codigoOdocumento)
        {
            var resultado = await _usuarioService.DeleteUsuarioAsync(codigoOdocumento);
            if (resultado == 1)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("toggle-state-cuenta/{codigoOdocumento}")]
        public async Task<ActionResult> ToggleEstadoCuenta(string codigoOdocumento)
        {
            var resultado = await _usuarioService.ToggleUsuarioCuentaAsync(codigoOdocumento);
            if (resultado == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("cuenta/{codigoOdocumento}")]
        public async Task<ActionResult<CuentumDto>> GetCuentaUsuario(string codigoOdocumento)
        {
            var cuentaDto = await _usuarioService.GetCuentaByUsuarioCodigoOrDocumentoAsync(codigoOdocumento);
            if (cuentaDto != null)
            {
                return Ok(cuentaDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
