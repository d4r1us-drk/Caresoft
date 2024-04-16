using caresoft_integration.Dto;
using caresoft_integration.Models;

namespace caresoft_integration.Services.Interfaces
{
    public interface IIngresoService
    {
        Task<int> AddIngresoAsync(IngresoDto ingresoDto);
        Task<int> UpdateIngresoAsync(IngresoDto ingresoDto);
        Task<int> DeleteIngresoAsync(uint idIngreso);
        Task<List<IngresoDto>> GetIngresosAsync();
        Task<IngresoDto?> GetIngresoByIdAsync(uint idIngreso);
        Task<int> AddIngresoAfeccionAsync(uint idIngreso, uint idAfeccion);
        Task<int> RemoveIngresoAfeccionAsync(uint idIngreso, uint idAfeccion);
        Task<List<Afeccion>> GetIngresoAfeccionesAsync(uint idIngreso);
    }
}
