using caresoft_core.Models;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class ProductoService : IProductoService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly LogHandler<ProductoService> _logHandler = new();

        public ProductoService(CaresoftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Producto>> GetProductosAsync(decimal? costo = null)
        {
            try
            {
                if (costo.HasValue)
                {
                    return await _dbContext.Productos.Where(p => p.Costo == costo).ToListAsync();
                }
                else
                {
                    return await _dbContext.Productos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Something went wrong", ex);
                throw;
            }
        }

        public async Task<int> AddProductoAsync(Producto producto)
        {
            try
            {
                _dbContext.Productos.Add(producto);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Something went wrong", ex);
                throw;
            }
        }

        public async Task<int> UpdateProductoAsync(ProductoDto producto)
        {
            try
            {
                var existingProduct = await _dbContext.Productos.FindAsync(producto.IdProducto);
                if (existingProduct == null)
                {
                    _logHandler.LogInfo($"Producto with ID {producto.IdProducto} not found.");
                    return 0;
                }

                if (producto.Nombre != null) {
                    existingProduct.Nombre = producto.Nombre;
                }

                if (producto.Descripcion != null) {
                    existingProduct.Descripcion = producto.Descripcion;
                }

                if (producto.Costo != null) {
                    existingProduct.Costo = producto.Costo ?? decimal.One;
                }

                if (producto.LoteDisponible != null) {
                    existingProduct.LoteDisponible = producto.LoteDisponible ?? uint.MinValue;
                }

                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Something went wrong", ex);
                throw;
            }
        }

        public async Task<int> DeleteProductoAsync(uint idProducto)
        {
            try
            {
                var producto = await _dbContext.Productos.FindAsync(idProducto);
                if (producto != null)
                {
                    _dbContext.Productos.Remove(producto);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0; // Return 0 if the product doesn't exist
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Something went wrong", ex);
                throw;
            }
        }

        public async Task<int> AddProductoProveedorAsync(uint idProducto, uint rncProveedor)
        {
            try
            {
                var producto = await _dbContext.Productos.FindAsync(idProducto);
                var proveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
                if (producto != null && proveedor != null)
                {
                    producto.RncProveedors.Add(proveedor);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0; // Return 0 if either the product or the provider doesn't exist
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Something went wrong", ex);
                throw;
            }
        }

        public async Task<int> DeleteProductoProveedorAsync(uint idProducto, uint rncProveedor)
        {
            try
            {
                var producto = await _dbContext.Productos.FindAsync(idProducto);
                var proveedor = await _dbContext.Proveedors.FindAsync(rncProveedor);
                if (producto != null && proveedor != null)
                {
                    producto.RncProveedors.Remove(proveedor);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0; // Return 0 if either the product or the provider doesn't exist
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Something went wrong", ex);
                throw;
            }
        }

        public async Task<List<uint>> GetProductoProveedoresAsync(uint idProducto)
        {
            try
            {
                var producto = await _dbContext.Productos.Include(p => p.RncProveedors).FirstOrDefaultAsync(p => p.IdProducto == idProducto);
                if (producto != null)
                {
                    return producto.RncProveedors.Select(p => p.RncProveedor).ToList();
                }
                return new List<uint>();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Something went wrong", ex);
                throw;
            }
        }
    }
}
