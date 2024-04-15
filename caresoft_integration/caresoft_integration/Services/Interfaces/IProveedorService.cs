using caresoft_core.Models;
using caresoft_core.Dto;

namespace caresoft_core.Services.Interfaces;

public interface IProveedorService
{
    Task<IEnumerable<ProveedorDto>> GetProveedoresAsync();
    Task<ProveedorDto> GetProveedorByIdAsync(uint rncProveedor);
    Task<int> CreateProveedorAsync(ProveedorDto proveedorDto);
    Task<int> UpdateProveedorAsync(ProveedorDto proveedorDto);
    Task<int> DeleteProveedorAsync(uint rncProveedor);
}