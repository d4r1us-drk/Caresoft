using caresoft_core.Context;
using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class ServicioService : IServicioService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly LogHandler<ServicioService> _logHandler = new LogHandler<ServicioService>();

        public ServicioService(CaresoftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateServicioAsync(ServicioDto servicioDto)
        {
            try
            {
                var servicio = new Servicio
                {
                    ServicioCodigo = servicioDto.ServicioCodigo,
                    IdTipoServicio = servicioDto.IdTipoServicio,
                    Nombre = servicioDto.Nombre,
                    Descripcion = servicioDto.Descripcion,
                    Costo = servicioDto.Costo
                };

                _dbContext.Servicios.Add(servicio);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Servicio created successfully.");
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
                return await _dbContext.Servicios
                    .Select(s => new ServicioDto
                    {
                        ServicioCodigo = s.ServicioCodigo,
                        IdTipoServicio = s.IdTipoServicio,
                        Nombre = s.Nombre,
                        Descripcion = s.Descripcion,
                        Costo = s.Costo
                    })
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
                var servicio = await _dbContext.Servicios.FindAsync(servicioDto.ServicioCodigo);
                if (servicio == null)
                {
                    _logHandler.LogInfo("Servicio not found.");
                    return 0;
                }

                servicio.IdTipoServicio = servicioDto.IdTipoServicio;
                servicio.Nombre = servicioDto.Nombre;
                servicio.Descripcion = servicioDto.Descripcion;
                servicio.Costo = servicioDto.Costo;

                _dbContext.Servicios.Update(servicio);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Servicio updated successfully.");
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
                var servicio = await _dbContext.Servicios.FindAsync(servicioCodigo);
                if (servicio == null)
                {
                    _logHandler.LogInfo("Servicio not found.");
                    return 0;
                }

                _dbContext.Servicios.Remove(servicio);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Servicio deleted successfully.");
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
