using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedorController(IProveedorService proveedorService) : ControllerBase
{
    [HttpGet("get")]
    public async Task<ActionResult<List<ProveedorDto>?>> GetProveedores()
    {
        try
        {
            var proveedores = await proveedorService.GetProveedoresAsync();
            return Ok(proveedores);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get/{rncProveedor}")]
    public async Task<ActionResult<ProveedorDto?>> GetProveedor(uint rncProveedor)
    {
        try
        {
            var proveedor = await proveedorService.GetProveedorByIdAsync(rncProveedor);
            if (proveedor == null)
            {
                return NotFound($"Proveedor with RNC {rncProveedor} not found");
            }
            return Ok(proveedor);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("add")]
    public async Task<ActionResult> CreateProveedor([FromQuery] ProveedorDto proveedor)
    {
        try
        {
            var result = await proveedorService.CreateProveedorAsync(proveedor);
            if (result == 0)
            {
                return Conflict($"Proveedor with RNC {proveedor.RncProveedor} already exists");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateProveedor([FromQuery] ProveedorDto proveedor)
    {
        try
        {
            var result = await proveedorService.UpdateProveedorAsync(proveedor);
            if (result == 0)
            {
                return NotFound($"Proveedor with RNC {proveedor.RncProveedor} not found");
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{rncProveedor}")]
    public async Task<ActionResult> DeleteProveedor(uint rncProveedor)
    {
        try
        {
            var result = await proveedorService.DeleteProveedorAsync(rncProveedor);
            if (result == 0)
            {
                return NotFound($"Proveedor with RNC {rncProveedor} not found");
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}