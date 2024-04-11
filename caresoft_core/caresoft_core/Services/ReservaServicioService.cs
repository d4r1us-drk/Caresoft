using caresoft_core.Models;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class ReservaServicioService : IReservaServicioService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly LogHandler<ReservaServicioService> _logHandler = new();

        public ReservaServicioService(CaresoftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ReservaServicio>> GetReservaServiciosListAsync(uint? idReserva, string? documentoPaciente, string? documentoMedico, string? servicioCodigo, DateTime? fechaReserva, string? estado)
        {
            try
            {
                var reservasQuery = _dbContext.ReservaServicios.AsQueryable();
        
                // Apply filters
                if (idReserva.HasValue && idReserva.Value != 0)
                    reservasQuery = reservasQuery.Where(r => r.IdReserva == idReserva.Value);
        
                if (!string.IsNullOrEmpty(documentoPaciente))
                    reservasQuery = reservasQuery.Where(r => r.DocumentoPaciente == documentoPaciente);
        
                if (!string.IsNullOrEmpty(documentoMedico))
                    reservasQuery = reservasQuery.Where(r => r.DocumentoMedico == documentoMedico);
        
                if (!string.IsNullOrEmpty(servicioCodigo))
                    reservasQuery = reservasQuery.Where(r => r.ServicioCodigo == servicioCodigo);
        
                if (fechaReserva != null)
                    reservasQuery = reservasQuery.Where(r => r.FechaReservada == fechaReserva);
        
                if (!string.IsNullOrEmpty(estado))
                    reservasQuery = reservasQuery.Where(r => r.Estado == estado);
        
                var reservas = await reservasQuery.ToListAsync();
                
                _logHandler.LogInfo("Data retrieved successfully.");
                return reservas;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
                return new List<ReservaServicio>();
            }
        }

        public async Task<int> AddReservaServicioAsync(ReservaServicio reserva)
        {
            try
            {
                _dbContext.ReservaServicios.Add(reserva);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo("ReservaServicio was successfully added.");
                return 1;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
                throw;
            }
        }

        public async Task<int> UpdateReservaServicioAsync(ReservaServicioDto reserva)
        {
            try
            {
                var existingReserva = await _dbContext.ReservaServicios.FindAsync(reserva.IdReserva);
                if (existingReserva == null)
                {
                    _logHandler.LogInfo($"ReservaServicio with ID {reserva.IdReserva} not found.");
                    return 0;
                }
        
                // Update only the properties that are not null
                if (reserva.DocumentoPaciente != null)
                {
                    existingReserva.DocumentoPaciente = reserva.DocumentoPaciente;
                }
        
                if (reserva.DocumentoMedico != null)
                {
                    existingReserva.DocumentoMedico = reserva.DocumentoMedico;
                }
        
                if (reserva.ServicioCodigo != null)
                {
                    existingReserva.ServicioCodigo = reserva.ServicioCodigo;
                }
        
                if (reserva.FechaReservada != null)
                {
                    existingReserva.FechaReservada = reserva.FechaReservada ?? DateTime.MinValue;
                }
        
                if (reserva.Estado != null)
                {
                    existingReserva.Estado = reserva.Estado;
                }
        
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
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
                    return await _dbContext.SaveChangesAsync();
                }
                else
                {
                    _logHandler.LogInfo($"ReservaServicio with ID {idReserva} not found.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
                throw;
            }
        }

        public async Task<int> DeleteReservaServicioAsync(uint idReserva)
        {
            try
            {
                var reserva = await _dbContext.ReservaServicios.FindAsync(idReserva);
                if (reserva != null)
                {
                    _dbContext.ReservaServicios.Remove(reserva);
                    return await _dbContext.SaveChangesAsync();
                }
                else
                {
                    _logHandler.LogInfo($"ReservaServicio with ID {idReserva} not found.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
                throw;
            }
        }
    }
}
