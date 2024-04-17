using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AfeccionService : IAfeccionService
{
    private readonly FallbackHttpClient _fallbackHttpClient;

    public AfeccionService(FallbackHttpClient fallbackHttpClient)
    {
        _fallbackHttpClient = fallbackHttpClient;
    }

    public async Task<int> CreateAfeccionAsync(Afeccion afeccion)
    {
        return await _fallbackHttpClient.CreateAfeccionAsync(afeccion);
    }

    public async Task<IEnumerable<Afeccion>> GetAfeccionesAsync()
    {
        return await _fallbackHttpClient.GetAfeccionesAsync();
    }

    public async Task<Afeccion> GetAfeccionByIdAsync(uint id)
    {
        return await _fallbackHttpClient.GetAfeccionByIdAsync((int)id);
    }

    public async Task<int> UpdateAfeccionAsync(Afeccion afeccion)
    {
        return await _fallbackHttpClient.UpdateAfeccionAsync(afeccion);
    }

    public async Task<int> DeleteAfeccionAsync(uint id)
    {
        return await _fallbackHttpClient.DeleteAfeccionAsync(id);
    }
}
