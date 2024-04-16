using caresoft_integration.Context;
using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Utils;
using caresoft_integration.Client;
using Microsoft.EntityFrameworkCore;

namespace caresoft_integration.Services;

public class PagoService : IPagoService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly CoreApiClient _coreApiClient;
    private readonly LogHandler<PagoService> _logHandler = new();

    public PagoService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
    {
        _dbContext = dbContext;
        _coreApiClient = coreApiClient;
    }

    public async Task<IEnumerable<Pago>> GetPagosAsync()
    {
        var pagos = await _coreApiClient.GetPagosAsync();
        return pagos.Any() ? pagos : await _dbContext.Pagos.ToListAsync();
    }

    public async Task<Pago> GetPagoByIdAsync(uint idPago)
    {
        var pago = await _coreApiClient.GetPagoByIdAsync(idPago);
        return pago ?? await _dbContext.Pagos.FindAsync(idPago);
    }

    public async Task<int> CreatePagoAsync(Pago pago)
    {
        int result = await _coreApiClient.CreatePagoAsync(pago);
        if (result == 1) return result;

        _dbContext.Pagos.Add(pago);
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> UpdatePagoAsync(Pago pago)
    {
        int result = await _coreApiClient.UpdatePagoAsync(pago);
        if (result == 1) return result;

        _dbContext.Entry(pago).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> DeletePagoAsync(uint idPago)
    {
        int result = await _coreApiClient.DeletePagoAsync(idPago);
        if (result == 1) return result;

        var pago = await _dbContext.Pagos.FindAsync(idPago);
        if (pago == null) return 0;

        _dbContext.Pagos.Remove(pago);
        await _dbContext.SaveChangesAsync();
        return 1;
    }
}
