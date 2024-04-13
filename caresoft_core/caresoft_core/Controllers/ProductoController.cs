using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;
    private readonly LogHandler<ProductoController> _logHandler = new();

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<ProductoDto>>> GetProductosAsync()
    {
        try
        {
            var productos = await _productoService.GetProductosAsync();
            return Ok(productos);
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while fetching products.", ex);
            return StatusCode(500, "An error occurred while fetching products.");
        }
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddProductoAsync([FromQuery] ProductoDto producto)
    {
        try
        {
            var result = await _productoService.AddProductoAsync(producto);
            if (result > 0)
            {
                return Ok("Product added successfully.");
            }

            return StatusCode(500, "An error occurred while adding product.");
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while adding product.", ex);
            return StatusCode(500, "An error occurred while adding product.");
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult> UpdateProductoAsync([FromQuery] ProductoDto producto)
    {
        try
        {
            var result = await _productoService.UpdateProductoAsync(producto);
            if (result > 0)
            {
                return Ok("Product updated successfully.");
            }

            return StatusCode(500, "An error occurred while updating product.");
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while updating product.", ex);
            return StatusCode(500, "An error occurred while updating product.");
        }
    }

    [HttpDelete("delete/{idProducto}")]
    public async Task<ActionResult> DeleteProductoAsync(uint idProducto)
    {
        try
        {
            var result = await _productoService.DeleteProductoAsync(idProducto);
            if (result > 0)
            {
                return Ok("Product deleted successfully.");
            }

            return StatusCode(500, $"An error occurred while deleting product with ID {idProducto}.");
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while deleting product.", ex);
            return StatusCode(500, "An error occurred while deleting product.");
        }
    }

    [HttpPost("add-provider")]
    public async Task<ActionResult> AddProductoProveedorAsync(
        [FromQuery] uint idProducto,
        [FromQuery] uint rncProveedor)
    {
        try
        {
            var result = await _productoService.AddProductoProveedorAsync(idProducto, rncProveedor);
            if (result > 0)
            {
                return Ok("Product provider added successfully.");
            }

            return StatusCode(500, $"An error occurred while adding product provider with ID {rncProveedor} to product with ID {idProducto}.");
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while adding product provider.", ex);
            return StatusCode(500, "An error occurred while adding product provider.");
        }
    }

    [HttpDelete("delete-provider")]
    public async Task<ActionResult> DeleteProductoProveedorAsync(
        [FromQuery] uint idProducto,
        [FromQuery] uint rncProveedor)
    {
        try
        {
            var result = await _productoService.DeleteProductoProveedorAsync(idProducto, rncProveedor);
            if (result > 0)
            {
                return Ok("Product provider deleted successfully.");
            }

            return StatusCode(500, $"An error occurred while deleting product provider with ID {rncProveedor} from product with ID {idProducto}.");
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while deleting product provider.", ex);
            return StatusCode(500, "An error occurred while deleting product provider.");
        }
    }

    [HttpGet("{idProducto}/proveedores")]
    public async Task<ActionResult<List<uint>>> GetProductoProveedoresAsync(uint idProducto)
    {
        try
        {
            var proveedores = await _productoService.GetProductoProveedoresAsync(idProducto);
            return Ok(proveedores);
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while fetching product providers.", ex);
            return StatusCode(500, "An error occurred while fetching product providers.");
        }
    }
}