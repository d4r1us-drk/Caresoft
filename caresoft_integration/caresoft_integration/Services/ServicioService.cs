using caresoft_core.Context;
using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class ServicioService(CaresoftDbContext dbContext) : IServicioService
{
    private readonly LogHandler<ServicioService> _logHandler = new();

    public async Task<int> CreateServicioAsync(ServicioDto servicioDto)
    {
        try
        {
            var servicio = Servicio.FromDto(servicioDto);
            dbContext.Servicios.Add(servicio);

            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to create servicio.", ex);
            throw;
        }
    }

    public async Task<List<ServicioDto>> GetServiciosAsync()
    {
        try
        {
            return await dbContext.Servicios
                .Select(s => ServicioDto.FromModel(s)).ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to retrieve servicios.", ex);
            throw;
        }
    }

    public async Task<int> UpdateServicioAsync(ServicioDto servicioDto)
    {
        try
        {
            var servicio = Servicio.FromDto(servicioDto);
            dbContext.Servicios.Update(servicio);

            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to update servicio.", ex);
            throw;
        }
    }

    public async Task<int> DeleteServicioAsync(string servicioCodigo)
    {
        try
        {
            var servicio = await dbContext.Servicios.FindAsync(servicioCodigo);
            if (servicio == null)
            {
                _logHandler.LogInfo("Servicio not found.");
                return 0;
            }

            dbContext.Servicios.Remove(servicio);

            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to delete servicio.", ex);
            throw;
        }
    }
}