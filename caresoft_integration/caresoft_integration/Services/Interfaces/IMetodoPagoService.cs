using caresoft_integration.Dto;

namespace caresoft_integration.Services.Interfaces
{
    public interface IMetodoPagoService
    {
        Task<int> AddMetodoPagoAsync(MetodoPagoDto metodoPago);
        Task<List<MetodoPagoDto>> GetMetodosPagoAsync();
        Task<int> UpdateMetodoPagoAsync(MetodoPagoDto metodoPago);
        Task<int> DeleteMetodoPagoAsync(uint idMetodoPago);
    }
}
