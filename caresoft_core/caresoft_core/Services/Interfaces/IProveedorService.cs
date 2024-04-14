using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces;

public interface IProveedorService
{
    Task<IEnumerable<Proveedor>> GetProveedoresAsync();
    Task<Proveedor> GetProveedorByIdAsync(uint rncProveedor);
    Task<int> CreateProveedorAsync(Proveedor proveedor);
    Task<int> UpdateProveedorAsync(Proveedor proveedor);
    Task<int> DeleteProveedorAsync(uint rncProveedor);
}