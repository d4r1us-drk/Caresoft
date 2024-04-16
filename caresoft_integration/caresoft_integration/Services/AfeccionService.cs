using caresoft_integration.Context;
using caresoft_integration.Models;
using caresoft_integration.Utils;
using caresoft_integration.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace caresoft_integration.Services;

public class AfeccionService(CaresoftDbContext dbContext) : IAfeccionService
{
    private readonly LogHandler<AfeccionService> _logHandler = new();

    public async Task<int> CreateAfeccionAsync(Afeccion afeccion)
    {
        try
        {
            dbContext.Afeccions.Add(afeccion);
            await dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error occurred while creating Afeccion.", ex);
            throw;
        }
    }

    public async Task<int> DeleteAfeccionAsync(uint id)
    {
        try
        {
            var afeccion = await dbContext.Afeccions.FindAsync(id);
            if (afeccion == null)
                return 0;

            dbContext.Afeccions.Remove(afeccion);
            await dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error occurred while deleting Afeccion.", ex);
            throw;
        }
    }

    public async Task<IEnumerable<Afeccion>> GetAfeccionesAsync()
    {
        try
        {
            return await dbContext.Afeccions.ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error occurred while getting Afecciones.", ex);
            throw;
        }
    }

    public async Task<Afeccion?> GetAfeccionByIdAsync(uint id)
    {
        try
        {
            return await dbContext.Afeccions.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logHandler.LogError($"Error occurred while getting Afeccion with ID: {id}.", ex);
            throw;
        }
    }

    public async Task<int> UpdateAfeccionAsync(Afeccion afeccion)
    {
        try
        {
            dbContext.Entry(afeccion).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return 1;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AfeccionExists(afeccion.IdAfeccion))
                return 0;
            throw;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error occurred while updating Afeccion.", ex);
            throw;
        }
    }

    private bool AfeccionExists(uint id)
    {
        return dbContext.Afeccions.Any(e => e.IdAfeccion == id);
    }
}