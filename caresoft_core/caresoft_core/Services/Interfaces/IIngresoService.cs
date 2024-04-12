using caresoft_core.Dto;

namespace caresoft_core.Services.Interfaces
{
    public interface IIngresoService
    {
        Task<int> AddIngresoAsync(IngresoDto ingresoDto);
        Task<int> UpdateIngresoAsync(IngresoDto ingresoDto);
        Task<int> DeleteIngresoAsync(uint idIngreso);
        Task<List<IngresoDto>> GetIngresosAsync();
        Task<IngresoDto?> GetIngresoByIdAsync(uint idIngreso);
    }
}
