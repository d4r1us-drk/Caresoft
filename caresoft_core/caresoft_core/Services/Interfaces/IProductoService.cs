using caresoft_core.Dto;

namespace caresoft_core.Services.Interfaces;

public interface IProductoService
{
    Task<List<ProductoDto>> GetProductosAsync();
    Task<int> AddProductoAsync(ProductoDto producto);
    Task<int> UpdateProductoAsync(ProductoDto producto);
    Task<int> DeleteProductoAsync(uint idProducto);
    Task<int> AddProductoProveedorAsync(uint idProducto, uint rncProveedor);
    Task<int> DeleteProductoProveedorAsync(uint idProducto, uint rncProveedor);
    Task<List<ProveedorDto>> GetProductoProveedoresAsync(uint idProducto);
}
