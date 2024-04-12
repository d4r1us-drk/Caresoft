using caresoft_core.Models;
using caresoft_core.Utils;
using caresoft_core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class ProductoService(CaresoftDbContext dbContext) : IProductoService
    {
        private readonly LogHandler<ProductoService> _logHandler = new();

        public async Task<List<Producto>> GetProductosAsync()
        {
            try
            {
                return await dbContext.Productos.ToListAsync();
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
                dbContext.Productos.Add(producto);
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Something went wrong", ex);
                throw;
            }
        }

        public async Task<int> UpdateProductoAsync(Producto producto)
        {
            try
            {
                dbContext.Productos.Update(producto);
                return await dbContext.SaveChangesAsync();
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
                var producto = await dbContext.Productos.FindAsync(idProducto);
                if (producto != null)
                {
                    dbContext.Productos.Remove(producto);
                    return await dbContext.SaveChangesAsync();
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
                var producto = await dbContext.Productos.FindAsync(idProducto);
                var proveedor = await dbContext.Proveedors.FindAsync(rncProveedor);
                if (producto != null && proveedor != null)
                {
                    producto.RncProveedors.Add(proveedor);
                    return await dbContext.SaveChangesAsync();
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
                var producto = await dbContext.Productos.FindAsync(idProducto);
                var proveedor = await dbContext.Proveedors.FindAsync(rncProveedor);
                if (producto != null && proveedor != null)
                {
                    producto.RncProveedors.Remove(proveedor);
                    return await dbContext.SaveChangesAsync();
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
                var producto = await dbContext.Productos.Include(p => p.RncProveedors).FirstOrDefaultAsync(p => p.IdProducto == idProducto);
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
