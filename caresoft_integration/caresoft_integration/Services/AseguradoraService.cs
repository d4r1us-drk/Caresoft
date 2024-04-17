using System.Collections.Generic;
using System.Threading.Tasks;
using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Client;

public class AseguradoraService : IAseguradoraService
{
    private readonly FallbackHttpClient _fallbackHttpClient;

    public AseguradoraService(FallbackHttpClient fallbackHttpClient)
    {
        _fallbackHttpClient = fallbackHttpClient;
    }

    public async Task<int> CreateAseguradora(Aseguradora aseguradora)
    {
        return await _fallbackHttpClient.CreateAseguradoraAsync(aseguradora);
    }

    public async Task<List<Aseguradora>> GetAllAseguradoras()
    {
        return await _fallbackHttpClient.GetAseguradorasAsync();
    }

    public async Task<Aseguradora?> GetAseguradoraById(uint id)
    {
        var aseguradoras = await GetAllAseguradoras();
        return aseguradoras.Find(a => a.IdAseguradora == id);
    }

    public async Task<int> UpdateAseguradora(Aseguradora aseguradora)
    {
        return await _fallbackHttpClient.UpdateAseguradoraAsync(aseguradora);
    }

    public async Task<int> DeleteAseguradora(uint id)
    {
        return await _fallbackHttpClient.DeleteAseguradoraAsync(id);
    }
}
