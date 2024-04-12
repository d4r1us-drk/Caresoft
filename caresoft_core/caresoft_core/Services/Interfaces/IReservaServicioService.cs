using caresoft_core.Models;
using caresoft_core.Dto;

namespace caresoft_core.Services.Interfaces;

public interface IReservaServicioService
{
    public Task<List<ReservaServicioDto>> GetReservaServiciosListAsync();
    public Task<int> AddReservaServicioAsync(ReservaServicio reserva);
    public Task<int> UpdateReservaServicioAsync(ReservaServicio reserva);
    public Task<int> ToggleEstadoReservaServicioAsync(uint idReserva);
    public Task<int> DeleteReservaServicioAsync(uint idReserva);
}
