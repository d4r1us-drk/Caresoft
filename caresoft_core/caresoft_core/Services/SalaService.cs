using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caresoft_core.Services
{
    public class SalaService : ISalaService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly LogHandler<SalaService> _logHandler = new LogHandler<SalaService>();

        public SalaService(CaresoftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateSalaAsync(SalaDto salaDto)
        {
            try
            {
                var sala = new Sala
                {
                    Estado = salaDto.Estado
                };

                _dbContext.Salas.Add(sala);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Sala created successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to create sala.", ex);
                throw;
            }
        }

        public async Task<List<SalaDto>> GetAllSalasAsync()
        {
            try
            {
                return await _dbContext.Salas
                    .Select(s => new SalaDto { NumSala = s.NumSala, Estado = s.Estado })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to retrieve salas.", ex);
                throw;
            }
        }

        public async Task<int> UpdateSalaEstadoAsync(uint numSala)
        {
            try
            {
                var sala = await _dbContext.Salas.FindAsync(numSala);
                if (sala == null)
                {
                    _logHandler.LogInfo("Sala not found.");
                    return 0;
                }

                sala.Estado = sala.Estado == "D" ? "O" : "D";
                _dbContext.Salas.Update(sala);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Sala estado toggled successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to toggle estado of sala.", ex);
                throw;
            }
        }

        public async Task<int> DeleteSalaAsync(uint numSala)
        {
            try
            {
                var sala = await _dbContext.Salas.FindAsync(numSala);
                if (sala == null)
                {
                    _logHandler.LogInfo("Sala not found.");
                    return 0;
                }

                _dbContext.Salas.Remove(sala);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("Sala deleted successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to delete sala.", ex);
                throw;
            }
        }

    }
}
