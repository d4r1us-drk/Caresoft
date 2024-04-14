using caresoft_core.Context;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class ProveedorService(CaresoftDbContext dbContext) : IProveedorService
{
    private readonly LogHandler<ProveedorService> _logHandler = new();

    public async Task<int> CreateProveedorAsync(Proveedor proveedor)
    {
        try
        {
            if (ProveedorExists(proveedor.RncProveedor))
            {
                return 0;
            }
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

    public async Task<Proveedor> GetProveedorByIdAsync(uint rncProveedor)
    {
        try
        {
            return await dbContext.Proveedors.FindAsync(rncProveedor);
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al obtener proveedor", ex);
            throw;
        }
    }

    public async Task<IEnumerable<Proveedor>> GetProveedoresAsync()
    {
        try
        {
            return await dbContext.Proveedors.ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al listar proveedores", ex);
            throw;
        }
    }

    public async Task<int> UpdateProveedorAsync(Proveedor proveedor)
    {
        try
        {
            dbContext.Entry(proveedor).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return 1;
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