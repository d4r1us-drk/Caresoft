using caresoft_integration.Models;
using caresoft_integration.Dto;

namespace caresoft_integration.Services.Interfaces;

public interface IReservaServicioService
{
    Task<List<ReservaServicioDto>> GetReservaServiciosListAsync();
    Task<int> AddReservaServicioAsync(ReservaServicioDto reservaServicioDto);
    Task<int> UpdateReservaServicioAsync(ReservaServicioDto reservaServicioDto);
    Task<int> ToggleEstadoReservaServicioAsync(int idReserva);
    Task<int> DeleteReservaServicioAsync(int idReserva);
}
