using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using caresoft_core.Context;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class AseguradoraService(CaresoftDbContext context) : IAseguradoraService
{
    private readonly LogHandler<AseguradoraService> _logHandler = new();

    public async Task<List<Aseguradora>> GetAllAseguradoras()
    {
        try
        {
            return await context.Aseguradoras.ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al obtener las aseguradoras", ex);
            throw;
        }
    }

    public async Task<Aseguradora?> GetAseguradoraById(uint id)
    {
        try
        {
            return await context.Aseguradoras.FindAsync(id);

        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al obtener la aseguradora", ex);
            throw;
        }
    }

    public async Task<int> UpdateAseguradora(Aseguradora aseguradora)
    {
        try
        {
            context.Entry(aseguradora).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AseguradoraExists(aseguradora.IdAseguradora))
                {
                    return 0;
                }
                throw;
            }
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al actualizar la aseguradora", ex);
            throw;
        }
    }

    public async Task<int> CreateAseguradora(Aseguradora aseguradora)
    {
        try
        {
            if (AseguradoraExists(aseguradora.IdAseguradora))
            {
                return 0;
            }
            context.Aseguradoras.Add(aseguradora);
            await context.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al crear la aseguradora", ex);
            throw;
        }
    }

    public async Task<int> DeleteAseguradora(uint id)
    {
        try
        {
            var aseguradora = await context.Aseguradoras.FindAsync(id);
            if (aseguradora == null)
            {
                return 0;
            }

            context.Aseguradoras.Remove(aseguradora);
            await context.SaveChangesAsync();

            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al eliminar la aseguradora", ex);
            throw;
        }
    }

    private bool AseguradoraExists(uint id)
    {
        return context.Aseguradoras.Any(e => e.IdAseguradora == id);
    }
}



