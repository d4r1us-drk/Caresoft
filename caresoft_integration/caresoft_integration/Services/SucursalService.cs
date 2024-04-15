using caresoft_core.Context;
using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using caresoft_integration.Client;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class SucursalService : ISucursalService
{
    private readonly CoreApiClient _coreApiClient;
    private readonly CaresoftDbContext _localDbContext;
    private readonly ILogger<SucursalService> _logger;

    public SucursalService(CoreApiClient coreApiClient, CaresoftDbContext localDbContext, ILogger<SucursalService> logger)
    {
        _coreApiClient = coreApiClient;
        _localDbContext = localDbContext;
        _logger = logger;
    }

    public async Task<int> CreateSucursalAsync(SucursalDto sucursalDto)
    {
        try
        {
            var result = await _coreApiClient.CreateSucursalAsync(sucursalDto);
            if (result == 1)
            {
                return 1;
            }
            else
            {
                throw new Exception("Core response was not successful.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to communicate with core. Error: {Error}", ex.Message);
            try
            {
                var sucursal = new Sucursal
                {
                    Nombre = sucursalDto.Nombre,
                    Direccion = sucursalDto.Direccion,
                    Telefono = sucursalDto.Telefono
                };
                _localDbContext.Add(sucursal);
                await _localDbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception dbEx)
            {
                _logger.LogError("Failed to create sucursal locally. Error: {Error}", dbEx.Message);
                throw;
            }
        }
    }

    public async Task<List<SucursalDto>> GetSucursalesAsync()
    {
        try
        {
            var sucursales = await _coreApiClient.GetSucursalesAsync();
            return sucursales;
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to retrieve sucursales from core. Trying local DB. Error: {Error}", ex.Message);
            return await _localDbContext.Sucursals
                .Select(s => new SucursalDto { IdSucursal = s.IdSucursal, Nombre = s.Nombre, Direccion = s.Direccion, Telefono = s.Telefono })
                .ToListAsync();
        }
    }

    public async Task<int> UpdateSucursalAsync(SucursalDto sucursalDto)
    {
        try
        {
            var result = await _coreApiClient.UpdateSucursalAsync(sucursalDto);
            if (result == 1)
            {
                return 1;
            }
            else
            {
                throw new Exception("Core response was not successful.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to communicate with core. Trying local update. Error: {Error}", ex.Message);
            try
            {
                var sucursal = await _localDbContext.Sucursals.FindAsync(sucursalDto.IdSucursal);
                if (sucursal == null)
                {
                    _logger.LogError("Sucursal not found locally.");
                    return 0;
                }
                sucursal.Nombre = sucursalDto.Nombre;
                sucursal.Direccion = sucursalDto.Direccion;
                sucursal.Telefono = sucursalDto.Telefono;
                _localDbContext.Update(sucursal);
                await _localDbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception dbEx)
            {
                _logger.LogError("Failed to update sucursal locally. Error: {Error}", dbEx.Message);
                throw;
            }
        }
    }

    public async Task<int> DeleteSucursalAsync(uint idSucursal)
    {
        try
        {
            // Intenta eliminar la sucursal a través del core
            var result = await _coreApiClient.DeleteSucursalAsync(idSucursal);
            if (result == 1)
            {
                return result; // Si el core responde correctamente, retorna el resultado
            }
            else
            {
                throw new Exception("Core response was not successful.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to communicate with core. Trying local deletion. Error: {Error}", ex.Message);
            // Si falla, intenta eliminar la sucursal en la base de datos local
            try
            {
                var sucursal = await _localDbContext.Sucursals.FindAsync(idSucursal);
                if (sucursal == null)
                {
                    _logger.LogError("Sucursal not found locally.");
                    return 0;
                }

                _localDbContext.Sucursals.Remove(sucursal);
                await _localDbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception dbEx)
            {
                _logger.LogError("Failed to delete sucursal locally. Error: {Error}", dbEx.Message);
                throw;
            }
        }
    }
}