namespace caresoft_core.Services;

using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AseguradoraService : IAseguradoraService
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

    public async Task<int> UpdateAseguradora(Aseguradora aseguradora)
    {
        try
        {


            _context.Entry(aseguradora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AseguradoraExists(aseguradora.IdAseguradora))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }

            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al actualizar la aseguradora", ex);
            throw;
        }
    }

    public async Task<int> CreateAseguradora(Aseguradora aseguradora)
    {
        try
        {
            if (this.AseguradoraExists(aseguradora.IdAseguradora))
            {
                return 0;
            }
            _context.Aseguradoras.Add(aseguradora);
            await _context.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Error al crear la aseguradora", ex);
            throw;
        }
    }

    public async Task<int> DeleteAseguradora(uint id)
    {
        try
        {
            var aseguradora = await _context.Aseguradoras.FindAsync(id);
            if (aseguradora == null)
            {
                return 0;
            }

            _context.Aseguradoras.Remove(aseguradora);
            await _context.SaveChangesAsync();

            return 1;
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



