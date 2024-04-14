using caresoft_core.Context;
using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly LogHandler<SucursalService> _logHandler = new LogHandler<SucursalService>();

        public SucursalService(CaresoftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateSucursalAsync(SucursalDto sucursalDto)
        {
            try
            {
                var sucursal = new Sucursal
                {
                    Nombre = sucursalDto.Nombre,
                    Direccion = sucursalDto.Direccion,
                    Telefono = sucursalDto.Telefono
                };

                _dbContext.Sucursals.Add(sucursal);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Sucursal created successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to create sucursal.", ex);
                throw;
            }
        }

        public async Task<List<SucursalDto>> GetSucursalesAsync()
        {
            try
            {
                return await _dbContext.Sucursals
                    .Select(s => new SucursalDto
                    {
                        IdSucursal = s.IdSucursal,
                        Nombre = s.Nombre,
                        Direccion = s.Direccion,
                        Telefono = s.Telefono
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to retrieve sucursales.", ex);
                throw;
            }
        }

        public async Task<int> UpdateSucursalAsync(SucursalDto sucursalDto)
        {
            try
            {
                var sucursal = await _dbContext.Sucursals.FindAsync(sucursalDto.IdSucursal);
                if (sucursal == null)
                {
                    _logHandler.LogInfo("Sucursal not found.");
                    return 0;
                }

                sucursal.Nombre = sucursalDto.Nombre;
                sucursal.Direccion = sucursalDto.Direccion;
                sucursal.Telefono = sucursalDto.Telefono;

                _dbContext.Sucursals.Update(sucursal);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Sucursal updated successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to update sucursal.", ex);
                throw;
            }
        }

        public async Task<int> DeleteSucursalAsync(uint idSucursal)
        {
            try
            {
                var sucursal = await _dbContext.Sucursals.FindAsync(idSucursal);
                if (sucursal == null)
                {
                    _logHandler.LogInfo("Sucursal not found.");
                    return 0;
                }

                _dbContext.Sucursals.Remove(sucursal);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Sucursal deleted successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to delete sucursal.", ex);
                throw;
            }
        }
    }
}
