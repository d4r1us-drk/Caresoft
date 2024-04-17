using caresoft_integration.Client;
using caresoft_integration.Dto;
using caresoft_integration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_integration.Services
{
    public class ReservaServicioService : IReservaServicioService
    {
        private readonly FallbackHttpClient _fallbackHttpClient;

        public ReservaServicioService(FallbackHttpClient fallbackHttpClient)
        {
            _fallbackHttpClient = fallbackHttpClient;
        }

        public async Task<List<ReservaServicioDto>> GetReservaServiciosListAsync()
        {
            return await _fallbackHttpClient.GetReservaServiciosListAsync();
        }

        public async Task<int> AddReservaServicioAsync(ReservaServicioDto reservaServicioDto)
        {
            return await _fallbackHttpClient.AddReservaServicioAsync(reservaServicioDto);
        }

        public async Task<int> UpdateReservaServicioAsync(ReservaServicioDto reservaServicioDto)
        {
            return await _fallbackHttpClient.UpdateReservaServicioAsync(reservaServicioDto);
        }

        public async Task<int> ToggleEstadoReservaServicioAsync(int idReserva)
        {
            return await _fallbackHttpClient.ToggleEstadoReservaServicioAsync(idReserva);
        }

        public async Task<int> DeleteReservaServicioAsync(int idReserva)
        {
            return await _fallbackHttpClient.DeleteReservaServicioAsync(idReserva);
        }
    }
}
