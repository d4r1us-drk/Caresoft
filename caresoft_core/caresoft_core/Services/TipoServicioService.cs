using caresoft_core.Context;
using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class TipoServicioService : ITipoServicioService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly LogHandler<TipoServicioService> _logHandler = new LogHandler<TipoServicioService>();

        public TipoServicioService(CaresoftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddTipoServicioAsync(TipoServicioDto tipoServicioDto)
        {
            try
            {
                var tipoServicio = new TipoServicio
                {
                    Nombre = tipoServicioDto.Nombre
                };

                _dbContext.TipoServicios.Add(tipoServicio);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Tipo de servicio creado con éxito.");
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
                var tipoServicio = await _dbContext.TipoServicios.FindAsync(tipoServicioDto.IdTipoServicio);
                if (tipoServicio == null)
                {
                    _logHandler.LogInfo("Tipo de servicio no encontrado.");
                    return 0;
                }

                tipoServicio.Nombre = tipoServicioDto.Nombre;
                _dbContext.TipoServicios.Update(tipoServicio);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Tipo de servicio actualizado con éxito.");
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
                var tipoServicio = await _dbContext.TipoServicios.FindAsync(idTipoServicio);
                if (tipoServicio == null)
                {
                    _logHandler.LogInfo("Tipo de servicio no encontrado.");
                    return 0;
                }

                _dbContext.TipoServicios.Remove(tipoServicio);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Tipo de servicio eliminado con éxito.");
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
