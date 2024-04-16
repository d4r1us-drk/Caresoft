using caresoft_integration.Context;
using caresoft_integration.Dto;
using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Utils;
using caresoft_integration.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caresoft_integration.Services
{
    public class MetodoPagoService : IMetodoPagoService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly CoreApiClient _coreApiClient;
        private readonly LogHandler<MetodoPagoService> _logHandler = new();

        public MetodoPagoService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
        {
            _dbContext = dbContext;
            _coreApiClient = coreApiClient;
        }

        public async Task<int> AddMetodoPagoAsync(MetodoPagoDto metodoPagoDto)
        {
            try
            {
                int result = await _coreApiClient.AddMetodoPagoAsync(metodoPagoDto);
                if (result == 1)
                {
                    _logHandler.LogInfo("MetodoPago added successfully via API.");
                    return result;
                }

                var newMetodoPago = new MetodoPago
                {
                    Nombre = metodoPagoDto.Nombre
                };

                _dbContext.MetodoPagos.Add(newMetodoPago);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("MetodoPago added successfully to local DB.");
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
                var metodosPago = await _coreApiClient.GetMetodosPagoAsync();
                if (metodosPago.Any())
                {
                    _logHandler.LogInfo("MetodosPago retrieved successfully via API.");
                    return metodosPago;
                }

                var localMetodosPago = await _dbContext.MetodoPagos
                    .Select(m => new MetodoPagoDto { IdMetodoPago = m.IdMetodoPago, Nombre = m.Nombre })
                    .ToListAsync();
                _logHandler.LogInfo("MetodosPago retrieved successfully from local DB.");
                return localMetodosPago;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to retrieve MetodosPago.", ex);
                throw;
            }
        }

        public async Task<int> UpdateMetodoPagoAsync(MetodoPagoDto metodoPagoDto)
        {
            try
            {
                int result = await _coreApiClient.UpdateMetodoPagoAsync(metodoPagoDto);
                if (result == 1)
                {
                    _logHandler.LogInfo("MetodoPago updated successfully via API.");
                    return result;
                }

                var existingMetodoPago = await _dbContext.MetodoPagos.FindAsync(metodoPagoDto.IdMetodoPago);
                if (existingMetodoPago == null)
                {
                    _logHandler.LogInfo("MetodoPago not found in local DB.");
                    return 0;
                }

                existingMetodoPago.Nombre = metodoPagoDto.Nombre;
                _dbContext.MetodoPagos.Update(existingMetodoPago);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("MetodoPago updated successfully in local DB.");
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
                int result = await _coreApiClient.DeleteMetodoPagoAsync(idMetodoPago);
                if (result == 1)
                {
                    _logHandler.LogInfo("MetodoPago deleted successfully via API.");
                    return result;
                }

                var metodoPago = await _dbContext.MetodoPagos.FindAsync(idMetodoPago);
                if (metodoPago == null)
                {
                    _logHandler.LogInfo("MetodoPago not found in local DB.");
                    return 0;
                }

                _dbContext.MetodoPagos.Remove(metodoPago);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("MetodoPago deleted successfully from local DB.");
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
