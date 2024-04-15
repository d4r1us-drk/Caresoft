using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Context;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using caresoft_integration.Client;

namespace caresoft_core.Services
{
    public class ReservaServicioService : IReservaServicioService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly CoreApiClient _coreApiClient;
        private readonly LogHandler<ReservaServicioService> _logHandler = new();

        public ReservaServicioService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
        {
            _dbContext = dbContext;
            _coreApiClient = coreApiClient;
        }

        public async Task<List<ReservaServicioDto>> GetReservaServiciosListAsync()
        {
            try
            {
                var reservas = await _coreApiClient.GetReservaServiciosListAsync();
                if (reservas.Count > 0) return reservas;

                return await _dbContext.ReservaServicios
                    .Select(r => ReservaServicioDto.FromModel(r))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to retrieve reserva servicios.", ex);
                throw;
            }
        }

        public async Task<int> AddReservaServicioAsync(ReservaServicioDto reserva)
        {
            try
            {
                return await _coreApiClient.AddReservaServicioAsync(reserva);
            }
            catch (HttpRequestException ex)
            {
                _logHandler.LogError("Error communicating with core API", ex);
                ReservaServicio newReserva = ReservaServicio.FromDto(reserva);
                _dbContext.ReservaServicios.Add(newReserva);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
        }

        public async Task<int> UpdateReservaServicioAsync(ReservaServicioDto reserva)
        {
            try
            {
                int result = await _coreApiClient.UpdateReservaServicioAsync(reserva);
                if (result == 1) return 1;

                ReservaServicio existingReserva = await _dbContext.ReservaServicios.FindAsync(reserva.IdReserva);
                if (existingReserva != null)
                {
                    existingReserva.DocumentoMedico = reserva.DocumentoMedico;
                    existingReserva.DocumentoPaciente = reserva.DocumentoPaciente;
                    existingReserva.ServicioCodigo = reserva.ServicioCodigo;
                    existingReserva.FechaReservada = reserva.FechaReservada;
                    existingReserva.Estado = reserva.Estado;
                    _dbContext.ReservaServicios.Update(existingReserva);
                    await _dbContext.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to update reserva servicio.", ex);
                throw;
            }
        }

        public async Task<int> ToggleEstadoReservaServicioAsync(uint idReserva)
        {
            try
            {
                var reserva = await _dbContext.ReservaServicios.FindAsync(idReserva);
                if (reserva != null)
                {
                    reserva.Estado = reserva.Estado == "P" ? "R" : "P";
                    await _dbContext.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Failed to toggle estado of reserva servicio.", ex);
                throw;
            }
        }

        public async Task<int> DeleteReservaServicioAsync(uint idReserva)
        {
            try
            {
                return await _coreApiClient.DeleteReservaServicioAsync(idReserva);
            }
            catch (HttpRequestException ex)
            {
                _logHandler.LogError("Error communicating with core API", ex);
                var reserva = await _dbContext.ReservaServicios.FindAsync(idReserva);
                if (reserva != null)
                {
                    _dbContext.ReservaServicios.Remove(reserva);
                    await _dbContext.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
        }
    }
}

