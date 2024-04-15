using caresoft_core.Dto;

namespace caresoft_core.Services.Interfaces
{
    public interface IMetodoPagoService
    {
        Task<int> AddMetodoPagoAsync(MetodoPagoDto metodoPago);
        Task<List<MetodoPagoDto>> GetMetodosPagoAsync();
        Task<int> UpdateMetodoPagoAsync(MetodoPagoDto metodoPago);
        Task<int> DeleteMetodoPagoAsync(uint idMetodoPago);
    }
}
