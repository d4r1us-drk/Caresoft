using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces;

public interface IReservaServicioService
{
    public Task<List<ReservaServicio>> GetReservaServiciosListAsync(uint? idReserva, string? documentoPaciente, string? documentoMedico, string? servicioCodigo, DateTime? fechaReserva, string? estado);
    public Task<int> AddReservaServicioAsync(ReservaServicio reserva);
    public Task<int> UpdateReservaServicioAsync(ReservaServicio reserva);
    public Task<int> ToggleEstadoReservaServicioAsync(uint idReserva);
    public Task<int> DeleteReservaServicioAsync(uint idReserva);
}
