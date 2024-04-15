using caresoft_core.Context;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using caresoft_integration.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caresoft_core.Services;

public class ProveedorService : IProveedorService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly CoreApiClient _coreApiClient;
    private readonly LogHandler<ProveedorService> _logHandler = new();

    public ProveedorService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
    {
        _dbContext = dbContext;
        _coreApiClient = coreApiClient;
    }

    public async Task<IEnumerable<Proveedor>> GetProveedoresAsync()
    {
        try
        {
            return await _coreApiClient.GetProveedoresAsync();
        }
        catch (Exception)
        {
            return await _dbContext.Proveedors.ToListAsync();
        }
    }

    public async Task<Proveedor> GetProveedorByIdAsync(uint rncProveedor)
    {
        try
        {
            return await _coreApiClient.GetProveedorByIdAsync(rncProveedor);
        }
        catch (Exception)
        {
            return await _dbContext.Proveedors.FindAsync(rncProveedor);
        }
    }

    public async Task<int> CreateProveedorAsync(Proveedor proveedor)
    {
        try
        {
            return await _coreApiClient.CreateProveedorAsync(proveedor);
        }
        catch (Exception)
        {
            if (_dbContext.Proveedors.Any(e => e.RncProveedor == proveedor.RncProveedor))
            {
                return 0; // Proveedor ya existe
            }
            _dbContext.Proveedors.Add(proveedor);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }

    public async Task<int> UpdateProveedorAsync(Proveedor proveedor)
    {
        try
        {
            return await _coreApiClient.UpdateProveedorAsync(proveedor);
        }
        catch (Exception)
        {
            _dbContext.Proveedors.Update(proveedor);
            return await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<int> DeleteProveedorAsync(uint rncProveedor)
    {
        try
        {
            return await _coreApiClient.DeleteProveedorAsync(rncProveedor);
        }
        catch (Exception)
        {
            var proveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
            if (proveedor == null) return 0;
            _dbContext.Proveedors.Remove(proveedor);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
}
