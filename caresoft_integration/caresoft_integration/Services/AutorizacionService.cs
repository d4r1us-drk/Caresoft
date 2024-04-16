using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AutorizacionService : IAutorizacionService
{
    private readonly FallbackHttpClient _fallbackHttpClient;

    public AutorizacionService(FallbackHttpClient fallbackHttpClient)
    {
        _fallbackHttpClient = fallbackHttpClient;
    }

    public async Task<int> CreateAutorizacionAsync(Autorizacion autorizacion, Aseguradora aseguradora)
    {
        return await _fallbackHttpClient.CreateAutorizacionAsync(autorizacion, aseguradora);
    }

    public async Task<Autorizacion> GetAutorizacionByIdAsync(uint id)
    {
        return await _fallbackHttpClient.GetAutorizacionByIdAsync(id);
    }

    public async Task<int> UpdateAutorizacionAsync(Autorizacion autorizacion, Aseguradora aseguradora)
    {
        return await _fallbackHttpClient.UpdateAutorizacionAsync(autorizacion, aseguradora);
    }

    public async Task<int> DeleteAutorizacionAsync(uint id)
    {
        return await _fallbackHttpClient.DeleteAutorizacionAsync(id);
    }

    public async Task<List<Autorizacion>> GetAllAutorizacionesAsync()
    {
        var autorizacionesDto = await _fallbackHttpClient.GetAllAutorizacionesAsync();
        var autorizaciones = autorizacionesDto.Select(dto => new Autorizacion
        {
            // Asumiendo que tienes un constructor o un método de mapeo similar en tu modelo Autorizacion
            IdAutorizacion = dto.IdAutorizacion,
            IdAseguradora = dto.IdAseguradora,
            Fecha = dto.Fecha,
            MontoAsegurado = dto.MontoAsegurado
        }).ToList();

        return autorizaciones;
    }
}
