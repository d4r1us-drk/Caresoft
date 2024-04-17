using caresoft_integration.Models;
using caresoft_integration.Dto;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Utils;
using Microsoft.EntityFrameworkCore;
using caresoft_integration.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caresoft_integration.Client;

namespace caresoft_integration.Services
{
    public class SalaService : ISalaService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly CoreApiClient _coreApiClient;
        private readonly LogHandler<SalaService> _logHandler = new LogHandler<SalaService>();

        public SalaService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
        {
            _dbContext = dbContext;
            _coreApiClient = coreApiClient;
        }

        public async Task<int> CreateSalaAsync(SalaDto salaDto)
        {
            try
            {
                int result = await _coreApiClient.CreateSalaAsync(salaDto);
                if (result == 1) return 1; // If successful, return 1

                var sala = new Sala
                {
                    Estado = salaDto.Estado
                };

                _dbContext.Salas.Add(sala);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to create sala.", ex);
                throw;
            }
        }

        public async Task<List<SalaDto>> GetSalasAsync()
        {
            try
            {
                var salas = await _coreApiClient.GetSalasAsync();
                if (salas.Count > 0) return salas;

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

                string nuevoEstado = sala.Estado == "D" ? "O" : "D";
                int result = await _coreApiClient.UpdateSalaEstadoAsync(numSala, nuevoEstado);
                if (result == 1) return 1;

                sala.Estado = nuevoEstado;
                _dbContext.Salas.Update(sala);
                await _dbContext.SaveChangesAsync();
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
                int result = await _coreApiClient.DeleteSalaAsync(numSala);
                if (result == 1) return 1; // Si fue exitoso, retorna 1

                var sala = await _dbContext.Salas.FindAsync(numSala);
                if (sala == null)
                {
                    _logHandler.LogInfo("Sala not found.");
                    return 0;
                }

                _dbContext.Salas.Remove(sala);
                await _dbContext.SaveChangesAsync();
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
