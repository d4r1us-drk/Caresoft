using caresoft_integration.Models;
using caresoft_integration.Dto;

namespace caresoft_integration.Services.Interfaces;

public interface IProveedorService
{
    Task<IEnumerable<ProveedorDto>> GetProveedoresAsync();
    Task<ProveedorDto> GetProveedorByIdAsync(uint rncProveedor);
    Task<int> CreateProveedorAsync(ProveedorDto proveedorDto);
    Task<int> UpdateProveedorAsync(ProveedorDto proveedorDto);
    Task<int> DeleteProveedorAsync(uint rncProveedor);
}