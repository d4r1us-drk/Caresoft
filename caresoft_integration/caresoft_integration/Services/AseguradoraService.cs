using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Context;
using caresoft_core.Utils;
using caresoft_integration.Client;

public class AseguradoraService : IAseguradoraService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly CoreApiClient _coreApiClient;
    private readonly LogHandler<AseguradoraService> _logHandler = new();

    public AseguradoraService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
    {
        _dbContext = dbContext;
        _coreApiClient = coreApiClient;
    }

    public async Task<int> CreateAseguradora(Aseguradora aseguradora)
    {
        var result = await _coreApiClient.CreateAseguradora(aseguradora);
        if (result == 1) return result;

        if (!AseguradoraExists(aseguradora.IdAseguradora))
        {
            _dbContext.Aseguradoras.Add(aseguradora);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        return 0;
    }

    public async Task<List<Aseguradora>> GetAllAseguradoras()
    {
        var aseguradoras = await _coreApiClient.GetAllAseguradoras();
        if (aseguradoras.Any()) return aseguradoras;

        return await _dbContext.Aseguradoras.ToListAsync();
    }

    public async Task<Aseguradora> GetAseguradoraById(uint id)
    {
        var aseguradora = await _coreApiClient.GetAseguradoraById(id);
        return aseguradora ?? await _dbContext.Aseguradoras.FindAsync(id);
    }

    public async Task<int> UpdateAseguradora(Aseguradora aseguradora)
    {
        var result = await _coreApiClient.UpdateAseguradora(aseguradora);
        if (result == 1) return result;

        _dbContext.Entry(aseguradora).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<int> DeleteAseguradora(uint id)
    {
        var result = await _coreApiClient.DeleteAseguradora(id);
        if (result == 1) return result;

        var aseguradora = await _dbContext.Aseguradoras.FindAsync(id);
        if (aseguradora == null) return 0;

        _dbContext.Aseguradoras.Remove(aseguradora);
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    private bool AseguradoraExists(uint id)
    {
        return _dbContext.Aseguradoras.Any(e => e.IdAseguradora == id);
    }
}
