using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<UsuarioDto>>> GetUsuariosByIdAsync(string id)
    {
        try
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
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
            var usuarios = await _usuarioService.GetUsuariosListAsync();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddUsuarioAsync([FromBody] UsuarioDto usuarioDto) {
        try {
            var usuario = Usuario.FromDto(usuarioDto);
            var perfilUsuario = PerfilUsuario.FromDto(usuarioDto);

            var result = await _usuarioService.AddUsuarioAsync(usuario, perfilUsuario);
            return Ok(result);
        } catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpPut("update")]

    public async Task<ActionResult<int>> UpdateUsuarioAsync([FromBody] UsuarioDto usuarioDto)
    {
        try
        {

            Usuario usuario = Usuario.FromDto(usuarioDto);
            PerfilUsuario perfilUsuario = PerfilUsuario.FromDto(usuarioDto);
            var result = await _usuarioService.UpdateUsuarioAsync(usuario, perfilUsuario);
            return Ok(result);
        }catch (Exception ex)
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

    [HttpPut("toggle-estado-cuenta")]
    public async Task<ActionResult<int>> ToggleUsuarioCuentaAsync([FromQuery] string codigoOdocumento)
    {
        try
        {
            var result = await _usuarioService.ToggleUsuarioCuentaAsync(codigoOdocumento);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}