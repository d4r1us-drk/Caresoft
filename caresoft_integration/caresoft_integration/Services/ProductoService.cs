using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using caresoft_core.Context;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class ProductoService(CaresoftDbContext _dbContext) : IProductoService
{
    private readonly LogHandler<ProductoService> _logHandler = new();

    public async Task<List<ProductoDto>> GetProductosAsync()
    {
        try
        {
            return (await _dbContext.Productos.ToListAsync()).Select(p => ProductoDto.FromModel(p)).ToList();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong", ex);
            throw;
        }
    }

    public async Task<int> AddProductoAsync(ProductoDto producto)
    {
        try
        {
            Producto result = Producto.FromDto(producto);
            _dbContext.Productos.Add(result);
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong", ex);
            throw;
        }
    }

    public async Task<int> UpdateProductoAsync(ProductoDto producto)
    {
        try
        {
            Producto result = Producto.FromDto(producto);
            _dbContext.Productos.Update(result);
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong", ex);
            throw;
        }
    }

    public async Task<int> DeleteProductoAsync(uint idProducto)
    {
        try
        {
            var producto = await _dbContext.Productos.FindAsync(idProducto);
            if (producto != null)
            {
                _dbContext.Productos.Remove(producto);
                return await _dbContext.SaveChangesAsync();
            }
            return 0; // Return 0 if the product doesn't exist
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong", ex);
            throw;
        }
    }

    public async Task<int> AddProductoProveedorAsync(uint idProducto, uint rncProveedor)
    {
        try
        {
            var producto = await _dbContext.Productos.FindAsync(idProducto);
            var proveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
            if (producto != null && proveedor != null)
            {
                producto.RncProveedors.Add(proveedor);
                return await _dbContext.SaveChangesAsync();
            }
            return 0; // Return 0 if either the product or the provider doesn't exist
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong", ex);
            throw;
        }
    }

    public async Task<int> DeleteProductoProveedorAsync(uint idProducto, uint rncProveedor)
    {
        try
        {
            var producto = await _dbContext.Productos.FindAsync(idProducto);
            var proveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
            if (producto != null && proveedor != null)
            {
                producto.RncProveedors.Remove(proveedor);
                return await _dbContext.SaveChangesAsync();
            }
            return 0; // Return 0 if either the product or the provider doesn't exist
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong", ex);
            throw;
        }
    }

    public async Task<List<uint>> GetProductoProveedoresAsync(uint idProducto)
    {
        try
        {
            var producto = await _dbContext.Productos.Include(p => p.RncProveedors).FirstOrDefaultAsync(p => p.IdProducto == idProducto);
            if (producto != null)
            {
                return producto.RncProveedors.Select(p => p.RncProveedor).ToList();
            }
            return new List<uint>();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong", ex);
            throw;
        }
    }
}