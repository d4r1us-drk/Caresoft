using caresoft_core.Context;
using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class ProveedorService(CaresoftDbContext dbContext) : IProveedorService
{
    private readonly LogHandler<ProveedorService> _logHandler = new();

    public async Task<int> CreateProveedorAsync(ProveedorDto proveedorDto)
    {
        try
        {
            if (ProveedorExists(proveedorDto.RncProveedor))
            {
                return 0;
            }
            var proveedor = Proveedor.FromDto(proveedorDto);
            dbContext.Proveedors.Add(proveedor);
            await dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al crear proveedor", ex);
            throw;
        }
    }

    public async Task<int> DeleteProveedorAsync(uint rncProveedor)
    {
        try
        {
            var proveedor = await dbContext.Proveedors.FindAsync(rncProveedor);
            if (proveedor == null)
            {
                return 0;
            }
            dbContext.Proveedors.Remove(proveedor);
            await dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al eliminar proveedor", ex);
            throw;
        }
    }

    public async Task<ProveedorDto> GetProveedorByIdAsync(uint rncProveedor)
    {
        try
        {
            var proveedor = await dbContext.Proveedors.FindAsync(rncProveedor);
            return ProveedorDto.FromModel(proveedor);
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al obtener proveedor", ex);
            throw;
        }
    }

    public async Task<IEnumerable<ProveedorDto>> GetProveedoresAsync()
    {
        try
        {
            return (await dbContext.Proveedors.ToListAsync()).Select(p => ProveedorDto.FromModel(p)).ToList();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al listar proveedores", ex);
            throw;
        }
    }

    public async Task<int> UpdateProveedorAsync(ProveedorDto proveedorDto)
    {
        try
        {
            var proveedor = Proveedor.FromDto(proveedorDto);
            dbContext.Proveedors.Update(proveedor);
            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al actualizar proveedor", ex);
            throw;
        }
    }

    private bool ProveedorExists(uint rncProveedor)
    {
        return dbContext.Proveedors.Any(e => e.RncProveedor == rncProveedor);
    }
}