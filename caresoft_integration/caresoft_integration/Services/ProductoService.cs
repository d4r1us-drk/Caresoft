using caresoft_integration.Models;
using caresoft_integration.Dto;
using caresoft_integration.Utils;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Context;
using Microsoft.EntityFrameworkCore;
using caresoft_integration.Client;

namespace caresoft_integration.Services;

public class ProductoService : IProductoService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly CoreApiClient _coreApiClient;
    private readonly LogHandler<ProductoService> _logHandler = new();

    public ProductoService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
    {
        _dbContext = dbContext;
        _coreApiClient = coreApiClient;
    }

    public async Task<List<ProductoDto>> GetProductosAsync()
    {
        var productos = await _coreApiClient.GetProductosAsync();
        if (productos.Any())
            return productos;

        // Fallback to local DB
        return await _dbContext.Productos
            .Select(p => ProductoDto.FromModel(p))
            .ToListAsync();
    }

    public async Task<int> AddProductoAsync(ProductoDto productoDto)
    {
        int result = await _coreApiClient.AddProductoAsync(productoDto);
        if (result == 1)
            return 1;

        // Fallback to local DB
        var producto = Producto.FromDto(productoDto);
        _dbContext.Productos.Add(producto);
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> UpdateProductoAsync(ProductoDto productoDto)
    {
        int result = await _coreApiClient.UpdateProductoAsync(productoDto);
        if (result == 1)
            return 1;

        // Fallback to local DB
        var producto = await _dbContext.Productos.FindAsync(productoDto.IdProducto);
        if (producto == null)
            return 0;

        producto.Nombre = productoDto.Nombre;
        producto.Descripcion = productoDto.Descripcion;
        producto.Costo = productoDto.Costo;
        producto.LoteDisponible = productoDto.LoteDisponible;
        _dbContext.Productos.Update(producto);
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> DeleteProductoAsync(uint idProducto)
    {
        int result = await _coreApiClient.DeleteProductoAsync(idProducto);
        if (result == 1)
            return 1;

        // Fallback to local DB
        var producto = await _dbContext.Productos.FindAsync(idProducto);
        if (producto == null)
            return 0;

        _dbContext.Productos.Remove(producto);
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> AddProductoProveedorAsync(uint idProducto, uint rncProveedor)
    {
        int result = await _coreApiClient.AddProductoProveedorAsync(idProducto, rncProveedor);
        if (result == 1)
            return 1;

        // Fallback to local DB
        var producto = await _dbContext.Productos.Include(p => p.RncProveedors).FirstOrDefaultAsync(p => p.IdProducto == idProducto);
        var proveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
        if (producto != null && proveedor != null)
        {
            producto.RncProveedors.Add(proveedor);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        return 0;
    }

    public async Task<int> DeleteProductoProveedorAsync(uint idProducto, uint rncProveedor)
    {
        int result = await _coreApiClient.DeleteProductoProveedorAsync(idProducto, rncProveedor);
        if (result == 1)
            return 1;

        // Fallback to local DB
        var producto = await _dbContext.Productos.Include(p => p.RncProveedors).FirstOrDefaultAsync(p => p.IdProducto == idProducto);
        var proveedor = producto?.RncProveedors.FirstOrDefault(p => p.RncProveedor == rncProveedor);
        if (producto != null && proveedor != null)
        {
            producto.RncProveedors.Remove(proveedor);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        return 0;
    }

    public async Task<List<uint>> GetProductoProveedoresAsync(uint idProducto)
    {
        var proveedores = await _coreApiClient.GetProductoProveedoresAsync(idProducto);
        if (proveedores.Any())
            return proveedores;

        // Fallback to local DB
        var producto = await _dbContext.Productos.Include(p => p.RncProveedors).FirstOrDefaultAsync(p => p.IdProducto == idProducto);
        return producto?.RncProveedors.Select(p => p.RncProveedor).ToList() ?? new List<uint>();
    }

}
