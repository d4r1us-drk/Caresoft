using Microsoft.AspNetCore.Mvc;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AseguradoraController : ControllerBase
{
    private readonly IAseguradoraService _aseguradoraService;

    public AseguradoraController(IAseguradoraService aseguradoraService)
    {
        _aseguradoraService = aseguradoraService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreateAseguradora([FromBody] Aseguradora aseguradora)
    {
        var result = await _aseguradoraService.CreateAseguradora(aseguradora);
        if (result == 1) return Ok();
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<Aseguradora>>> GetAseguradoras()
    {
        var aseguradoras = await _aseguradoraService.GetAllAseguradoras();
        return Ok(aseguradoras);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateAseguradora([FromRoute] uint id, [FromBody] Aseguradora aseguradora)
    {

        aseguradora.IdAseguradora = id; // Asegúrate de que el ID es el correcto
        var result = await _aseguradoraService.UpdateAseguradora(aseguradora);
        if (result == 1) return Ok();
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAseguradora([FromRoute] uint id)
    {
        var result = await _aseguradoraService.DeleteAseguradora(id);
        if (result == 1) return Ok();
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
