using caresoft_core.Models;
using caresoft_core.Context;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services;

public class ConsultorioService(CaresoftDbContext dbContext) : IConsultorioService
{
    private readonly LogHandler<ConsultorioService> _logHandler = new();

    public async Task<IEnumerable<Consultorio>> GetConsultoriosAsync()
    {
        try
        {
            return await dbContext.Consultorios.ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to get Consultorios data.", ex);
            throw;
        }
    }

    public async Task<Consultorio> GetConsultorioByIdAsync(uint idConsultorio)
    {
        try
        {
            return await dbContext.Consultorios.FindAsync(idConsultorio);
        }
        catch (Exception ex)
        {
            _logHandler.LogError($"Something went wrong while trying to get Consultorio with ID {idConsultorio}.", ex);
            throw;
        }
    }

    public async Task<int> CreateConsultorioAsync(Consultorio consultorio)
    {
        try
        {
            dbContext.Consultorios.Add(consultorio);
            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to create a Consultorio.", ex);
            throw;
        }
    }

    public async Task<int> UpdateConsultorioAsync(Consultorio consultorio)
    {
        try
        {
            dbContext.Entry(consultorio).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to update a Consultorio.", ex);
            throw;
        }
    }

    public async Task<int> DeleteConsultorioAsync(uint idConsultorio)
    {
        try
        {
            var consultorio = await dbContext.Consultorios.FindAsync(idConsultorio);
            if (consultorio == null)
            {
                return 0;
            }

            dbContext.Consultorios.Remove(consultorio);
            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError($"Something went wrong while trying to delete Consultorio with ID {idConsultorio}.", ex);
            throw;
        }
    }
}