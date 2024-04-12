namespace caresoft_core.Services;

using caresoft_core.Models;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AseguradoraService
{
    private readonly CaresoftDbContext _context;
    private readonly LogHandler<AseguradoraService> _logHandler = new();
    public AseguradoraService(CaresoftDbContext context) => _context = context;
    public async Task<List<Aseguradora>> GetAllAseguradoras()
    {
        try
        {
            return await _context.Aseguradoras.ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al obtener las aseguradoras", ex);
            throw;
        }
    }

    public async Task<Aseguradora?> GetAseguradoraById(uint id)
    {
        try
        {
            return await _context.Aseguradoras.FindAsync(id);

        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al obtener la aseguradora", ex);
            throw;
        }
    }

    public async Task<bool> UpdateAseguradora(uint id, Aseguradora aseguradora)
    {
        try
        {
            if (id != aseguradora.IdAseguradora)
            {
                return false;
            }

            _context.Entry(aseguradora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AseguradoraExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al actualizar la aseguradora", ex);
            throw;
        }
    }

    public async Task<Aseguradora> CreateAseguradora(Aseguradora aseguradora)
    {
        try
        {
            _context.Aseguradoras.Add(aseguradora);
            await _context.SaveChangesAsync();

            return aseguradora;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al crear la aseguradora", ex);
            throw;
        }
    }

    public async Task<bool> DeleteAseguradora(uint id)
    {
        try
        {
            var aseguradora = await _context.Aseguradoras.FindAsync(id);
            if (aseguradora == null)
            {
                return false;
            }

            _context.Aseguradoras.Remove(aseguradora);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al eliminar la aseguradora", ex);
            throw;
        }
    }

    private bool AseguradoraExists(uint id)
    {
        return _context.Aseguradoras.Any(e => e.IdAseguradora == id);
    }
}



