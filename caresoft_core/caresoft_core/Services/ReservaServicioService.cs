using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Context;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class ReservaServicioService : IReservaServicioService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly LogHandler<ReservaServicioService> _logHandler = new();

    public ReservaServicioService(CaresoftDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ReservaServicioDto>> GetReservaServiciosListAsync()
    {
        try
        {
            var reservas = await _dbContext.ReservaServicios.ToListAsync();

            // Manually map ReservaServicio entities to ReservaServicioDto objects
            var reservaDtoList = reservas.Select(r => new ReservaServicioDto
            {
                IdReserva = r.IdReserva,
                DocumentoPaciente = r.DocumentoPaciente,
                DocumentoMedico = r.DocumentoMedico,
                ServicioCodigo = r.ServicioCodigo,
                FechaReservada = r.FechaReservada,
                Estado = r.Estado
            }).ToList();

            _logHandler.LogInfo("Data retrieved successfully.");
            return reservaDtoList;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            return new List<ReservaServicioDto>();
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

    public async Task<int> UpdateReservaServicioAsync(ReservaServicio reserva)
    {
        try
        {
            _dbContext.ReservaServicios.Update(reserva);
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