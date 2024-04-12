using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly CaresoftDbContext _context;
        private readonly LogHandler<AutorizacionService> _logHandler = new();

        public AutorizacionService(CaresoftDbContext context)
        {
            _context = context;
        }

        public async Task<Autorizacion?> GetAutorizacionById(uint idAutorizacion)
        {
            try
            {
                return await _context.Autorizacions.FindAsync(idAutorizacion);

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
                if(this.AutorizacionExists(autorizacion.IdAutorizacion))
                {
                    return 0;
                }
                _context.Autorizacions.Add(autorizacion);
                await _context.SaveChangesAsync();
                return 1;
            } catch(Exception ex)
            {
                _logHandler.LogError("Error al crear autorizacion", ex);
                throw;
            }
        }

        public async Task<int> ActualizarAutorizacion(Autorizacion autorizacion)
        {

            _context.Entry(autorizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorizacionExists(autorizacion.IdAutorizacion))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }

        }

        public async Task<int> EliminarAutorizacion(uint idAutorizacion)
        {
            try { 
            var autorizacion = await _context.Autorizacions.FindAsync(idAutorizacion);
            if (autorizacion == null)
            {
                return 0;
            }

            _context.Autorizacions.Remove(autorizacion);
            await _context.SaveChangesAsync();

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
                return await _context.Autorizacions.ToListAsync();
            } catch(Exception ex)
            {
                _logHandler.LogError("Error al listar autorizaciones", ex);
                throw;
            }
        }
        private bool AutorizacionExists(uint id)
        {
            return _context.Autorizacions.Any(e => e.IdAutorizacion == id);
        }
    }
}
