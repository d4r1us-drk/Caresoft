using caresoft_integration.Dto;

namespace caresoft_integration.Services.Interfaces
{
    public interface ISucursalService
    {
        Task<int> CreateSucursalAsync(SucursalDto sucursalDto);
        Task<List<SucursalDto>> GetSucursalesAsync();
        Task<int> UpdateSucursalAsync(SucursalDto sucursalDto);
        Task<int> DeleteSucursalAsync(uint idSucursal);
    }
}
