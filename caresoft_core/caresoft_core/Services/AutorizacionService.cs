using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using caresoft_core.Context;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class AutorizacionService : IAutorizacionService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly LogHandler<AutorizacionService> _logHandler = new();

    public AutorizacionService(CaresoftDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Autorizacion?> GetAutorizacionById(uint idAutorizacion)
    {
        try
        {
            return await _dbContext.Autorizacions.FindAsync(idAutorizacion);

        } catch(Exception ex)
        {
            _logHandler.LogError("Error al obtener autorizacion", ex);
            throw;
        }

    }

    public async Task<int> CrearAutorizacion(Autorizacion autorizacion)
    {
        try
        {
            if(AutorizacionExists(autorizacion.IdAutorizacion))
            {
                return 0;
            }
            _dbContext.Autorizacions.Add(autorizacion);
            await _dbContext.SaveChangesAsync();
            return 1;
        } catch(Exception ex)
        {
            _logHandler.LogError("Error al crear autorizacion", ex);
            throw;
        }
    }

    public async Task<int> ActualizarAutorizacion(Autorizacion autorizacion)
    {
        _dbContext.Entry(autorizacion).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AutorizacionExists(autorizacion.IdAutorizacion))
            {
                return 0;
            }

            throw;
        }

    }

    public async Task<int> EliminarAutorizacion(uint idAutorizacion)
    {
        try {
            var autorizacion = await _dbContext.Autorizacions.FindAsync(idAutorizacion);
            if (autorizacion == null)
            {
                return 0;
            }

            _dbContext.Autorizacions.Remove(autorizacion);
            await _dbContext.SaveChangesAsync();

            return 1;
        } catch(Exception ex)
        {
            _logHandler.LogError("Error al eliminar autorizacion", ex);
            throw;
        }

    }

    public async Task<List<Autorizacion>> ListarAutorizaciones()
    {
        try
        {
            return await _dbContext.Autorizacions.ToListAsync();
        } catch(Exception ex)
        {
            _logHandler.LogError("Error al listar autorizaciones", ex);
            throw;
        }
    }

    private bool AutorizacionExists(uint id)
    {
        return _dbContext.Autorizacions.Any(e => e.IdAutorizacion == id);
    }
}