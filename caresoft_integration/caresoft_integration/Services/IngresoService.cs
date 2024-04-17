using caresoft_integration.Models;
using caresoft_integration.Dto;
using Microsoft.EntityFrameworkCore;
using caresoft_integration.Context;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Utils;

namespace caresoft_integration.Services;

public class IngresoService(CaresoftDbContext dbContext) : IIngresoService
{
    private readonly LogHandler<IngresoService> _logHandler = new();

    public async Task<int> AddIngresoAsync(IngresoDto ingresoDto)
    {
        try
        {
            var ingreso = Ingreso.FromDto(ingresoDto);

            dbContext.Ingresos.Add(ingreso);
            await dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Ingreso added successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to add ingreso.", ex);
            throw;
        }
    }

    public async Task<int> UpdateIngresoAsync(IngresoDto ingresoDto)
    {
        try
        {
            var ingreso = await dbContext.Ingresos.FindAsync(ingresoDto.IdIngreso);

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

            dbContext.Ingresos.Update(ingreso);
            await dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Ingreso updated successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to update ingreso.", ex);
            throw;
        }
    }

    public async Task<int> DeleteIngresoAsync(uint idIngreso)
    {
        try
        {
            var ingreso = await dbContext.Ingresos.FindAsync(idIngreso);
            if (ingreso == null)
            {
                _logHandler.LogInfo("Ingreso not found.");
                return 0;
            }

            dbContext.Ingresos.Remove(ingreso);
            await dbContext.SaveChangesAsync();
            _logHandler.LogInfo("Ingreso deleted successfully.");
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to delete ingreso.", ex);
            throw;
        }
    }

    public async Task<List<IngresoDto>> GetIngresosAsync()
    {
        try
        {
            return await dbContext.Ingresos.Select(i => IngresoDto.FromModel(i)).ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to retrieve ingresos.", ex);
            throw;
        }
    }

    public async Task<IngresoDto?> GetIngresoByIdAsync(uint idIngreso)
    {
        try
        {
            return await dbContext.Ingresos
                .Where(i => i.IdIngreso == idIngreso)
                .Select(i => IngresoDto.FromModel(i)).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Failed to retrieve ingreso by ID.", ex);
            throw;
        }
    }

    public async Task<int> AddIngresoAfeccionAsync(uint idIngreso, uint idAfeccion)
    {
        var ingreso = await dbContext.Ingresos
            .Include(i => i.IdAfeccions)
            .FirstOrDefaultAsync(i => i.IdIngreso == idIngreso);

        if (ingreso == null) return 0;

        var afeccion = await dbContext.Afeccions.FindAsync(idAfeccion);
        if (afeccion == null) return 0;

        ingreso.IdAfeccions.Add(afeccion);
        await dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> RemoveIngresoAfeccionAsync(uint idIngreso, uint idAfeccion)
    {
        var ingreso = await dbContext.Ingresos
            .Include(i => i.IdAfeccions)
            .FirstOrDefaultAsync(i => i.IdIngreso == idIngreso);

        if (ingreso == null) return 0;

        var afeccion = ingreso.IdAfeccions.FirstOrDefault(a => a.IdAfeccion == idAfeccion);
        if (afeccion == null) return 0;

        ingreso.IdAfeccions.Remove(afeccion);
        await dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<List<Afeccion>> GetIngresoAfeccionesAsync(uint idIngreso)
    {
        var ingreso = await dbContext.Ingresos
            .Include(i => i.IdAfeccions)
            .FirstOrDefaultAsync(i => i.IdIngreso == idIngreso);

        return ingreso?.IdAfeccions.ToList() ?? new List<Afeccion>();
    }
}
