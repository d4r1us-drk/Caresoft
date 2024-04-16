using caresoft_integration.Context;
using caresoft_integration.Dto;
using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Utils;
using caresoft_integration.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_integration.Services
{
    public class ServicioService : IServicioService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly CoreApiClient _coreApiClient;
        private readonly LogHandler<ServicioService> _logHandler = new();

        public ServicioService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
        {
            _dbContext = dbContext;
            _coreApiClient = coreApiClient;
        }

        public async Task<int> CreateServicioAsync(ServicioDto servicioDto)
        {
            try
            {
                int result = await _coreApiClient.CreateServicioAsync(servicioDto);
                if (result == 1) return 1; 

                
                var servicio = Servicio.FromDto(servicioDto);
                _dbContext.Servicios.Add(servicio);
                await _dbContext.SaveChangesAsync();
                return 1;
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
                var servicios = await _coreApiClient.GetServiciosAsync();
                if (servicios.Count > 0) return servicios; 

                
                return await _dbContext.Servicios
                    .Select(s => ServicioDto.FromModel(s))
                    .ToListAsync();
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
                int result = await _coreApiClient.UpdateServicioAsync(servicioDto);
                if (result == 1) return 1;

               
                var servicio = await _dbContext.Servicios.FindAsync(servicioDto.ServicioCodigo);
                if (servicio == null)
                {
                    _logHandler.LogInfo("Servicio not found.");
                    return 0;
                }

                servicio.Nombre = servicioDto.Nombre;
                servicio.Descripcion = servicioDto.Descripcion;
                servicio.Costo = servicioDto.Costo;
                servicio.IdTipoServicio = servicioDto.IdTipoServicio;
                _dbContext.Servicios.Update(servicio);
                await _dbContext.SaveChangesAsync();
                return 1;
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
                int result = await _coreApiClient.DeleteServicioAsync(servicioCodigo);
                if (result == 1) return 1;

                
                var servicio = await _dbContext.Servicios.FindAsync(servicioCodigo);
                if (servicio == null)
                {
                    _logHandler.LogInfo("Servicio not found.");
                    return 0;
                }

                _dbContext.Servicios.Remove(servicio);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to delete servicio.", ex);
                throw;
            }
        }
    }
}
