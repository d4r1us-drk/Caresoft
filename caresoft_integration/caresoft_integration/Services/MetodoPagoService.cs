using caresoft_core.Context;
using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class MetodoPagoService : IMetodoPagoService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly LogHandler<MetodoPagoService> _logHandler = new LogHandler<MetodoPagoService>();

        public MetodoPagoService(CaresoftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddMetodoPagoAsync(MetodoPagoDto metodoPago)
        {
            try
            {
                var newMetodoPago = new MetodoPago
                {
                    Nombre = metodoPago.Nombre
                };

                _dbContext.MetodoPagos.Add(newMetodoPago);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("MetodoPago added successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to add MetodoPago.", ex);
                throw;
            }
        }

        public async Task<List<MetodoPagoDto>> GetMetodosPagoAsync()
        {
            try
            {
                return await _dbContext.MetodoPagos
                    .Select(m => new MetodoPagoDto { IdMetodoPago = m.IdMetodoPago, Nombre = m.Nombre })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to retrieve MetodoPagos.", ex);
                throw;
            }
        }

        public async Task<int> UpdateMetodoPagoAsync(MetodoPagoDto metodoPago)
        {
            try
            {
                var existingMetodoPago = await _dbContext.MetodoPagos.FindAsync(metodoPago.IdMetodoPago);
                if (existingMetodoPago == null)
                {
                    _logHandler.LogInfo("MetodoPago not found.");
                    return 0;
                }

                existingMetodoPago.Nombre = metodoPago.Nombre;

                _dbContext.MetodoPagos.Update(existingMetodoPago);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("MetodoPago updated successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to update MetodoPago.", ex);
                throw;
            }
        }

        public async Task<int> DeleteMetodoPagoAsync(uint idMetodoPago)
        {
            try
            {
                var metodoPago = await _dbContext.MetodoPagos.FindAsync(idMetodoPago);
                if (metodoPago == null)
                {
                    _logHandler.LogInfo("MetodoPago not found.");
                    return 0;
                }

                _dbContext.MetodoPagos.Remove(metodoPago);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("MetodoPago deleted successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to delete MetodoPago.", ex);
                throw;
            }
        }
    }
}
