using caresoft_integration.Models;
using caresoft_integration.Dto;

namespace caresoft_integration.Services.Interfaces;

public interface IReservaServicioService
{
    public Task<List<ReservaServicioDto>> GetReservaServiciosListAsync();
    public Task<int> AddReservaServicioAsync(ReservaServicioDto reserva);
    public Task<int> UpdateReservaServicioAsync(ReservaServicioDto reserva);
    public Task<int> ToggleEstadoReservaServicioAsync(uint idReserva);
    public Task<int> DeleteReservaServicioAsync(uint idReserva);
}
