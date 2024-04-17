using caresoft_core.Context;
using caresoft_core.Dto;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace caresoft_core.Services;

public class PagoService(CaresoftDbContext dbContext) : IPagoService
{
    private readonly LogHandler<PagoService> _logHandler = new();

    public async Task<int> CreatePagoAsync(Pago pago)
    {
        try
        {
            dbContext.Pagos.Add(pago);
            await dbContext.SaveChangesAsync();
            return 1;
        }
        catch (MySqlException ex)
        {
            _logHandler.LogError("Error creating Pago", ex);
            throw;
        }
    }

    public async Task<int> DeletePagoAsync(uint idPago)
    {
        try
        {
            var pago = await dbContext.Pagos.FindAsync(idPago);
            if (pago == null)
                return 0;

            dbContext.Pagos.Remove(pago);
            await dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError($"Error deleting Pago with id {idPago}", ex);
            throw;
        }
    }

    public async Task<IEnumerable<Pago>> GetPagosAsync()
    {
        try
        {
            return await dbContext.Pagos.ToListAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error retrieving Pagos", ex);
            throw;
        }
    }

    public async Task<Pago?> GetPagoByIdAsync(uint idPago)
    {
        try
        {
            return await dbContext.Pagos.FindAsync(idPago);
        }
        catch (Exception ex)
        {
            _logHandler.LogError($"Error retrieving Pago with id {idPago}", ex);
            throw;
        }
    }

    public async Task<int> UpdatePagoAsync(Pago pago)
    {
        try
        {
            dbContext.Entry(pago).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError($"Error updating Pago with id {pago.IdPago}", ex);
            throw;
        }
    }
}