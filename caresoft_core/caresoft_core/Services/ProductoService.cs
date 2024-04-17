using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using caresoft_core.Context;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace caresoft_core.Services;

public class ProductoService(CaresoftDbContext dbContext) : IProductoService
{
    private readonly LogHandler<ProductoService> _logHandler = new();

    public async Task<List<ProductoDto>> GetProductosAsync()
    {
        try
        {
            return (await dbContext.Productos.ToListAsync()).Select(p => ProductoDto.FromModel(p)).ToList();
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
            dbContext.Productos.Add(result);
            return await dbContext.SaveChangesAsync();
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
            var result = Producto.FromDto(producto);
            dbContext.Productos.Update(result);
            return await dbContext.SaveChangesAsync();
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
            var producto = await dbContext.Productos.FindAsync(idProducto);
            if (producto != null)
            {
                dbContext.Productos.Remove(producto);
                return await dbContext.SaveChangesAsync();
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
            var producto = await dbContext.Productos.FindAsync(idProducto);
            var proveedor = await dbContext.Proveedors.FindAsync(rncProveedor);
            if (producto != null && proveedor != null)
            {
                producto.RncProveedors.Add(proveedor);
                return await dbContext.SaveChangesAsync();
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
            // Construct the SQL command to delete the relationship from the bridge table
            var sql = "DELETE FROM Proveedor_Producto WHERE IdProducto = @idProducto AND RncProveedor = @rncProveedor";

            // Execute the raw SQL command
            var parameters = new[] {
                new MySqlParameter("@idProducto", idProducto),
                new MySqlParameter("@rncProveedor", rncProveedor)
            };
            var result = await dbContext.Database.ExecuteSqlRawAsync(sql, parameters);

            return result;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong", ex);
            throw;
        }
    }

    public async Task<List<ProveedorDto>> GetProductoProveedoresAsync(uint idProducto)
    {
        try
        {
            var producto = await dbContext.Productos
                .Include(p => p.RncProveedors)
                .FirstOrDefaultAsync(p => p.IdProducto == idProducto);

            if (producto != null)
            {
                var proveedorDtos = producto.RncProveedors
                    .Select(proveedor => ProveedorDto.FromModel(proveedor))
                    .ToList();

                return proveedorDtos;
            }
            return new List<ProveedorDto>(); // Return an empty list if the producto is not found
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong", ex);
            throw;
        }
    }
}