using caresoft_core.Dto;

namespace caresoft_core.Services.Interfaces
{
    public interface IServicioService
    {
        Task<int> CreateServicioAsync(ServicioDto servicioDto);
        Task<List<ServicioDto>> GetServiciosAsync();
        Task<int> UpdateServicioAsync(ServicioDto servicioDto);
        Task<int> DeleteServicioAsync(string servicioCodigo);
    }
}
