using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController(IProductoService productoService) : ControllerBase
{
    private readonly LogHandler<ProductoController> _logHandler = new();

    [HttpGet("get")]
    public async Task<ActionResult<List<ProductoDto>>> GetProductosAsync()
    {
        try
        {
            var productos = await productoService.GetProductosAsync();
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
            var result = await productoService.AddProductoAsync(producto);
            if (result > 0)
                return Ok("Product added successfully.");

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
            var result = await productoService.UpdateProductoAsync(producto);
            if (result > 0)
                return Ok("Product updated successfully.");

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
            var result = await productoService.DeleteProductoAsync(idProducto);
            if (result > 0)
                return Ok("Product deleted successfully.");

            return StatusCode(500, $"An error occurred while deleting product with ID {idProducto}.");
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while deleting product.", ex);
            return StatusCode(500, "An error occurred while deleting product.");
        }
    }

    [HttpPost("add-provider/{idProducto}/{rncProveedor}")]
    public async Task<ActionResult> AddProductoProveedorAsync(uint idProducto, uint rncProveedor)
    {
        try
        {
            var result = await productoService.AddProductoProveedorAsync(idProducto, rncProveedor);
            if (result > 0)
                return Ok("Product provider added successfully.");

            return StatusCode(500, $"An error occurred while adding product provider with ID {rncProveedor} to product with ID {idProducto}.");
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while adding product provider.", ex);
            return StatusCode(500, "An error occurred while adding product provider.");
        }
    }

    [HttpDelete("delete-provider/{idProducto}/{rncProveedor}")]
    public async Task<ActionResult> DeleteProductoProveedorAsync(uint idProducto, uint rncProveedor)
    {
        try
        {
            var result = await productoService.DeleteProductoProveedorAsync(idProducto, rncProveedor);
            if (result > 0)
                return Ok("Product provider deleted successfully.");

            return StatusCode(500, $"An error occurred while deleting product provider with ID {rncProveedor} from product with ID {idProducto}.");
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while deleting product provider.", ex);
            return StatusCode(500, "An error occurred while deleting product provider.");
        }
    }

    [HttpGet("{idProducto}/proveedores")]
    public async Task<ActionResult<List<ProveedorDto>>> GetProductoProveedoresAsync(uint idProducto)
    {
        try
        {
            var proveedores = await productoService.GetProductoProveedoresAsync(idProducto);
            return Ok(proveedores);
        }
        catch (Exception ex)
        {
            _logHandler.LogError("An error occurred while fetching product providers.", ex);
            return StatusCode(500, "An error occurred while fetching product providers.");
        }
    }
}