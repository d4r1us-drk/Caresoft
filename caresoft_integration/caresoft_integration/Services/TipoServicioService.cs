using caresoft_core.Context;
using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using caresoft_integration.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_core.Services
{
    public class TipoServicioService : ITipoServicioService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly CoreApiClient _coreApiClient;
        private readonly LogHandler<TipoServicioService> _logHandler = new();

        public TipoServicioService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
        {
            _dbContext = dbContext;
            _coreApiClient = coreApiClient;
        }

        public async Task<int> AddTipoServicioAsync(TipoServicioDto tipoServicioDto)
        {
            try
            {
                int result = await _coreApiClient.CreateTipoServicioAsync(tipoServicioDto);
                if (result == 1) return 1; // Si fue exitoso, retorna 1

                var tipoServicio = new TipoServicio
                {
                    Nombre = tipoServicioDto.Nombre
                };
                _dbContext.TipoServicios.Add(tipoServicio);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al crear el tipo de servicio.", ex);
                throw;
            }
        }

        public async Task<List<TipoServicioDto>> GetTipoServiciosAsync()
        {
            try
            {
                var tipoServicios = await _coreApiClient.GetTipoServiciosAsync();
                if (tipoServicios.Count > 0) return tipoServicios;

                return await _dbContext.TipoServicios
                    .Select(ts => new TipoServicioDto { IdTipoServicio = ts.IdTipoServicio, Nombre = ts.Nombre })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al recuperar los tipos de servicios.", ex);
                throw;
            }
        }

        public async Task<int> UpdateTipoServicioAsync(TipoServicioDto tipoServicioDto)
        {
            try
            {
                int result = await _coreApiClient.UpdateTipoServicioAsync(tipoServicioDto);
                if (result == 1) return 1; // Si fue exitoso, retorna 1

                var tipoServicio = await _dbContext.TipoServicios.FindAsync(tipoServicioDto.IdTipoServicio);
                if (tipoServicio == null)
                {
                    _logHandler.LogInfo("Tipo de servicio no encontrado.");
                    return 0;
                }

                tipoServicio.Nombre = tipoServicioDto.Nombre;
                _dbContext.TipoServicios.Update(tipoServicio);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al actualizar el tipo de servicio.", ex);
                throw;
            }
        }

        public async Task<int> DeleteTipoServicioAsync(uint idTipoServicio)
        {
            try
            {
                int result = await _coreApiClient.DeleteTipoServicioAsync(idTipoServicio);
                if (result == 1) return 1; // Si fue exitoso, retorna 1

                var tipoServicio = await _dbContext.TipoServicios.FindAsync(idTipoServicio);
                if (tipoServicio == null)
                {
                    _logHandler.LogInfo("Tipo de servicio no encontrado.");
                    return 0;
                }

                _dbContext.TipoServicios.Remove(tipoServicio);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al eliminar el tipo de servicio.", ex);
                throw;
            }
        }
    }
}
