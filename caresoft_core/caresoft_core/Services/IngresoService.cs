using caresoft_core.Models;
using caresoft_core.Dto;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;

namespace caresoft_core.Services;

public class IngresoService : IIngresoService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly LogHandler<IngresoService> _logHandler = new();

    public IngresoService(CaresoftDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddIngresoAsync(IngresoDto ingresoDto)
    {
        try
        {
            var ingreso = new Ingreso
            {
                DocumentoPaciente = ingresoDto.DocumentoPaciente,
                DocumentoEnfermero = ingresoDto.DocumentoEnfermero,
                DocumentoMedico = ingresoDto.DocumentoMedico,
                ConsultaCodigo = ingresoDto.ConsultaCodigo,
                IdAutorizacion = ingresoDto.IdAutorizacion,
                NumSala = ingresoDto.NumSala,
                CostoEstancia = ingresoDto.CostoEstancia,
                FechaIngreso = ingresoDto.FechaIngreso,
                FechaAlta = ingresoDto.FechaAlta
            };

            _dbContext.Ingresos.Add(ingreso);
            await _dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Ingreso added successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Failed to add ingreso.", ex);
            throw;
        }
    }

    public async Task<int> UpdateIngresoAsync(IngresoDto ingresoDto)
    {
        try
        {
            var ingreso = await _dbContext.Ingresos.FindAsync(ingresoDto.IdIngreso);
            if (ingreso == null)
            {
                _logHandler.LogInfo("Ingreso not found.");
                return 0;
            }

            ingreso.DocumentoPaciente = ingresoDto.DocumentoPaciente;
            ingreso.DocumentoEnfermero = ingresoDto.DocumentoEnfermero;
            ingreso.DocumentoMedico = ingresoDto.DocumentoMedico;
            ingreso.ConsultaCodigo = ingresoDto.ConsultaCodigo;
            ingreso.IdAutorizacion = ingresoDto.IdAutorizacion;
            ingreso.NumSala = ingresoDto.NumSala;
            ingreso.CostoEstancia = ingresoDto.CostoEstancia;
            ingreso.FechaIngreso = ingresoDto.FechaIngreso;
            ingreso.FechaAlta = ingresoDto.FechaAlta;

            _dbContext.Ingresos.Update(ingreso);
            await _dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Ingreso updated successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Failed to update ingreso.", ex);
            throw;
        }
    }

    public async Task<int> DeleteIngresoAsync(uint idIngreso)
    {
        try
        {
            var ingreso = await _dbContext.Ingresos.FindAsync(idIngreso);
            if (ingreso == null)
            {
                _logHandler.LogInfo("Ingreso not found.");
                return 0;
            }

            _dbContext.Ingresos.Remove(ingreso);
            await _dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Ingreso deleted successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Failed to delete ingreso.", ex);
            throw;
        }
    }

    public async Task<List<IngresoDto>> GetIngresosAsync()
    {
        try
        {
            return await _dbContext.Ingresos
                .Select(ingreso => new IngresoDto
                {
                    IdIngreso = ingreso.IdIngreso,
                    DocumentoPaciente = ingreso.DocumentoPaciente,
                    DocumentoEnfermero = ingreso.DocumentoEnfermero,
                    DocumentoMedico = ingreso.DocumentoMedico,
                    ConsultaCodigo = ingreso.ConsultaCodigo,
                    IdAutorizacion = ingreso.IdAutorizacion,
                    NumSala = ingreso.NumSala,
                    CostoEstancia = ingreso.CostoEstancia,
                    FechaIngreso = ingreso.FechaIngreso,
                    FechaAlta = ingreso.FechaAlta
                })
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Failed to retrieve ingresos.", ex);
            throw;
        }
    }

    public async Task<IngresoDto> GetIngresoByIdAsync(uint idIngreso)
    {
        try
        {
            return await _dbContext.Ingresos
                .Where(ingreso => ingreso.IdIngreso == idIngreso)
                .Select(ingreso => new IngresoDto
                {
                    IdIngreso = ingreso.IdIngreso,
                    DocumentoPaciente = ingreso.DocumentoPaciente,
                    DocumentoEnfermero = ingreso.DocumentoEnfermero,
                    DocumentoMedico = ingreso.DocumentoMedico,
                    ConsultaCodigo = ingreso.ConsultaCodigo,
                    IdAutorizacion = ingreso.IdAutorizacion,
                    NumSala = ingreso.NumSala,
                    CostoEstancia = ingreso.CostoEstancia,
                    FechaIngreso = ingreso.FechaIngreso,
                    FechaAlta = ingreso.FechaAlta
                })
                .FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Failed to retrieve ingreso by ID.", ex);
            throw;
        }
    }
}
