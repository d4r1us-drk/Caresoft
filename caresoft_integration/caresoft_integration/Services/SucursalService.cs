using caresoft_core.Context;
using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class SucursalService(CaresoftDbContext dbContext) : ISucursalService
{
    private readonly LogHandler<SucursalService> _logHandler = new();

    public async Task<int> CreateSucursalAsync(SucursalDto sucursalDto)
    {
        try
        {
            var sucursal = Sucursal.FromDto(sucursalDto);
            dbContext.Sucursals.Add(sucursal);

            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to create sucursal.", ex);
            throw;
        }
    }

    public async Task<List<SucursalDto>> GetSucursalesAsync()
    {
        try
        {
            var sucursales = await dbContext.Sucursals.ToListAsync();
            return sucursales.Select(SucursalDto.FromModel).ToList();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to retrieve sucursales.", ex);
            throw;
        }
    }

    public async Task<int> UpdateSucursalAsync(SucursalDto sucursalDto)
    {
        try
        {
            var sucursal = Sucursal.FromDto(sucursalDto);

            dbContext.Sucursals.Update(sucursal);
            await dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Sucursal updated successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to update sucursal.", ex);
            throw;
        }
    }

    public async Task<int> DeleteSucursalAsync(uint idSucursal)
    {
        try
        {
            var sucursal = await dbContext.Sucursals.FindAsync(idSucursal);
            if (sucursal == null)
            {
                _logHandler.LogInfo("Sucursal not found.");
                return 0;
            }

            dbContext.Sucursals.Remove(sucursal);
            await dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Sucursal deleted successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to delete sucursal.", ex);
            throw;
        }
    }
}