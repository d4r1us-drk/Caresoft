using caresoft_core.Context;
using caresoft_core.Dto;
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
    private readonly LogHandler<ProveedorService> _logHandler = new LogHandler<ProveedorService>();

    public ProveedorService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
    {
        _dbContext = dbContext;
        _coreApiClient = coreApiClient;
    }

    public async Task<IEnumerable<ProveedorDto>> GetProveedoresAsync()
    {
        var proveedores = await _coreApiClient.GetProveedoresAsync();
        if (proveedores.Any())
            return proveedores;

        // Fallback to local DB
        return await _dbContext.Proveedors
            .Select(p => ProveedorDto.FromModel(p))
            .ToListAsync();
    }

    public async Task<ProveedorDto> GetProveedorByIdAsync(uint rncProveedor)
    {
        var proveedor = await _coreApiClient.GetProveedorByIdAsync(rncProveedor);
        if (proveedor != null)
            return proveedor;

        // Fallback to local DB
        var localProveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
        return localProveedor != null ? ProveedorDto.FromModel(localProveedor) : null;
    }

    public async Task<int> CreateProveedorAsync(ProveedorDto proveedorDto)
    {
        int result = await _coreApiClient.CreateProveedorAsync(proveedorDto);
        if (result == 1)
            return 1;

        // Fallback to local DB
        var proveedor = Proveedor.FromDto(proveedorDto);
        _dbContext.Proveedors.Add(proveedor);
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> UpdateProveedorAsync(ProveedorDto proveedorDto)
    {
        int result = await _coreApiClient.UpdateProveedorAsync(proveedorDto);
        if (result == 1)
            return 1;

        // Fallback to local DB
        var proveedor = await _dbContext.Proveedors.FindAsync(proveedorDto.RncProveedor);
        if (proveedor == null)
            return 0;

        proveedor.Nombre = proveedorDto.Nombre;
        proveedor.Direccion = proveedorDto.Direccion;
        proveedor.Telefono = proveedorDto.Telefono;
        proveedor.Correo = proveedorDto.Correo;
        _dbContext.Proveedors.Update(proveedor);
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> DeleteProveedorAsync(uint rncProveedor)
    {
        int result = await _coreApiClient.DeleteProveedorAsync(rncProveedor);
        if (result == 1)
            return 1;

        // Fallback to local DB
        var proveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
        if (proveedor == null)
            return 0;

        _dbContext.Proveedors.Remove(proveedor);
        await _dbContext.SaveChangesAsync();
        return 1;
    }
}