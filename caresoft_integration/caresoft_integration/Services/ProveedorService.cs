using caresoft_core.Context;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class ProveedorService : IProveedorService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly LogHandler<ProveedorService> _logHandler = new LogHandler<ProveedorService>();

    public ProveedorService(CaresoftDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateProveedorAsync(Proveedor proveedor)
    {
        try
        {
            if (_dbContext.Proveedors.Any(e => e.RncProveedor == proveedor.RncProveedor))
            {
                _logHandler.LogInfo($"Proveedor with RNC {proveedor.RncProveedor} already exists.");
                return 0;  // RNC already exists
            }

            _dbContext.Proveedors.Add(proveedor);
            await _dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Proveedor created successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to create proveedor.", ex);
            throw;
        }
    }

    public async Task<IEnumerable<Proveedor>> GetProveedoresAsync()
    {
        try
        {
            return await _dbContext.Proveedors.ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to retrieve proveedores.", ex);
            throw;
        }
    }

    public async Task<Proveedor> GetProveedorByIdAsync(uint rncProveedor)
    {
        try
        {
            var proveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
            if (proveedor == null)
            {
                _logHandler.LogInfo($"Proveedor with RNC {rncProveedor} not found.");
                return null;
            }
            return proveedor;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to retrieve proveedor.", ex);
            throw;
        }
    }

    public async Task<int> UpdateProveedorAsync(Proveedor proveedor)
    {
        try
        {
            var existingProveedor = await _dbContext.Proveedors.FindAsync(proveedor.RncProveedor);
            if (existingProveedor == null)
            {
                _logHandler.LogInfo($"Proveedor with RNC {proveedor.RncProveedor} not found.");
                return 0;
            }

            existingProveedor.Nombre = proveedor.Nombre;
            existingProveedor.Direccion = proveedor.Direccion;
            existingProveedor.Telefono = proveedor.Telefono;
            existingProveedor.Correo = proveedor.Correo;

            _dbContext.Proveedors.Update(existingProveedor);
            await _dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Proveedor updated successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to update proveedor.", ex);
            throw;
        }
    }

    public async Task<int> DeleteProveedorAsync(uint rncProveedor)
    {
        try
        {
            var proveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
            if (proveedor == null)
            {
                _logHandler.LogInfo($"Proveedor with RNC {rncProveedor} not found.");
                return 0;
            }

            _dbContext.Proveedors.Remove(proveedor);
            await _dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Proveedor deleted successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to delete proveedor.", ex);
            throw;
        }
    }
}