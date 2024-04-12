using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces;

public interface IProductoService
{
    Task<List<Producto>> GetProductosAsync(decimal? costo = null);
    Task<int> AddProductoAsync(Producto producto);
    Task<int> UpdateProductoAsync(Producto producto);
    Task<int> DeleteProductoAsync(uint idProducto);
    Task<int> AddProductoProveedorAsync(uint idProducto, uint rncProveedor);
    Task<int> DeleteProductoProveedorAsync(uint idProducto, uint rncProveedor);
    Task<List<uint>> GetProductoProveedoresAsync(uint idProducto);
}
