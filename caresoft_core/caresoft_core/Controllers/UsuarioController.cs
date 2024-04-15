using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
{
    [HttpGet("get/{codigoODocumento}")]
    public async Task<ActionResult<UsuarioDto>> GetUsuariosByIdAsync(string codigoODocumento)
    {
        try
        {
            var usuario = await usuarioService.GetUsuarioByIdAsync(codigoODocumento);
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<UsuarioDto>>> GetUsuariosListAsync()
    {
        try
        {
            var usuarios = await usuarioService.GetUsuariosListAsync();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddUsuarioAsync([FromQuery] UsuarioDto usuario) {
        try
        {
            var result = await usuarioService.AddUsuarioAsync(usuario);
            return Ok(result);
        } 
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpPut("update")]

    public async Task<ActionResult<int>> UpdateUsuarioAsync([FromQuery] UsuarioDto usuario)
    {
        try
        {
            var result = await usuarioService.UpdateUsuarioAsync(usuario);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{codigoOdocumento}")]
    public async Task<ActionResult<int>> DeleteUsuarioAsync(string codigoOdocumento)
    {
        try
        {
            var result = await usuarioService.DeleteUsuarioAsync(codigoOdocumento);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("cuenta/{codigoOdocumento}")]
    public async Task<ActionResult<CuentumDto>> GetCuentaByUsuarioCodigoOrDocumentoAsync(string codigoOdocumento)
    {
        try
        {
            var cuenta = await usuarioService.GetCuentaByUsuarioCodigoOrDocumentoAsync(codigoOdocumento);
            if (cuenta != null)
            {
                return Ok(cuenta);
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("toggle-state-cuenta/{codigoOdocumento}")]
    public async Task<ActionResult<int>> ToggleUsuarioCuentaAsync(string codigoOdocumento)
    {
        try
        {
            var result = await usuarioService.ToggleUsuarioCuentaAsync(codigoOdocumento);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}