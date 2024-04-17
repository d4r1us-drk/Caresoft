using caresoft_integration.Models;
using caresoft_integration.Dto;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Utils;
using Microsoft.EntityFrameworkCore;
using caresoft_integration.Context;

namespace caresoft_integration.Services;

public class FacturaService(CaresoftDbContext dbContext) : IFacturaService
{
    private readonly LogHandler<FacturaService> _logHandler = new();

    public async Task<int> AddFacturaAsync(FacturaDto facturaDto)
    {
        try
        {
            var factura = Factura.FromDto(facturaDto);
            dbContext.Facturas.Add(factura);
            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while creating a Factura.", ex);
            throw;
        }
    }

    public async Task<int> UpdateFacturaAsync(FacturaDto facturaDto)
    {
        try
        {
            var factura = Factura.FromDto(facturaDto);
            dbContext.Facturas.Update(factura);
            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while updating a Factura.", ex);
            throw;
        }
    }

    public async Task<int> DeleteFacturaAsync(string facturaCodigo)
    {
        try
        {
            var factura = await dbContext.Facturas.FirstOrDefaultAsync(f => f.FacturaCodigo == facturaCodigo);
            if (factura != null)
            {
                dbContext.Facturas.Remove(factura);
                return await dbContext.SaveChangesAsync();
            }
            return 0; // Return 0 if no record is deleted
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to delete a Factura.", ex);
            throw;
        }
    }

    public async Task<IEnumerable<FacturaDto>> GetFacturasAsync()
    {
        try
        {
            var facturas = await dbContext.Facturas.ToListAsync();
            return facturas.Select(FacturaDto.FromModel);
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to get Facturas data.", ex);
            throw;
        }
    }

    public async Task<int> AddFacturaServicioAsync(FacturaServicioDto facturaServicioDto)
    {
        try
        {
            var facturaServicio = FacturaServicio.FromDto(facturaServicioDto);
            dbContext.FacturaServicios.Add(facturaServicio);
            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to make a FacturaServicio relation.", ex);
            throw;
        }
    }

    public async Task<int> DeleteFacturaServicioAsync(string facturaCodigo, string servicioCodigo)
    {
        try
        {
            var facturaServicio = await dbContext.FacturaServicios.FirstOrDefaultAsync(fs => fs.FacturaCodigo == facturaCodigo && fs.ServicioCodigo == servicioCodigo);
            if (facturaServicio != null)
            {
                dbContext.FacturaServicios.Remove(facturaServicio);
                return await dbContext.SaveChangesAsync();
            }
            return 0; // Return 0 if no record is deleted
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to delete a FacturaServicio relation.", ex);
            throw;
        }
    }

    public async Task<IEnumerable<FacturaServicioDto>> GetFacturaServiciosAsync(string facturaCodigo)
    {
        try
        {
            var facturaServicios = await dbContext.FacturaServicios
                .Where(fs => fs.FacturaCodigo == facturaCodigo)
                .ToListAsync();

            return facturaServicios.Select(FacturaServicioDto.FromModel);
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to get FacturaServicio relations.", ex);
            throw;
        }
    }

    public async Task<int> AddFacturaProductoAsync(FacturaProductoDto facturaProductoDto)
    {
        try
        {
            var facturaProducto = FacturaProducto.FromDto(facturaProductoDto);
            dbContext.FacturaProductos.Add(facturaProducto);
            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to make a FacturaProducto relation.", ex);
            throw;
        }
    }

    public async Task<int> DeleteFacturaProductoAsync(string facturaCodigo, uint idProducto)
    {
        try
        {
            var facturaProducto = await dbContext.FacturaProductos.FirstOrDefaultAsync(fp => fp.FacturaCodigo == facturaCodigo && fp.IdProducto == idProducto);
            if (facturaProducto != null)
            {
                dbContext.FacturaProductos.Remove(facturaProducto);
                return await dbContext.SaveChangesAsync();
            }
            return 0; // Return 0 if no record is deleted
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to delete a FacturaProducto relation.", ex);
            throw;
        }
    }

    public async Task<IEnumerable<FacturaProductoDto>> GetFacturaProductosAsync(string facturaCodigo)
    {
        try
        {
            var facturaProductos = await dbContext.FacturaProductos
                .Where(fp => fp.FacturaCodigo == facturaCodigo)
                .ToListAsync();

            return facturaProductos.Select(FacturaProductoDto.FromModel);
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to get FacturaProductos relations.", ex);
            throw;
        }
    }

    public async Task<int> AddFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
    {
        try
        {
            var factura = await dbContext.Facturas.FirstOrDefaultAsync(f => f.FacturaCodigo == facturaCodigo);
            if (factura != null)
            {
                var metodoPago = await dbContext.MetodoPagos.FirstOrDefaultAsync(mp => mp.IdMetodoPago == idMetodoPago);
                if (metodoPago != null)
                {
                    factura.IdMetodoPagos.Add(metodoPago);
                    return await dbContext.SaveChangesAsync();
                }
            }
            return 0; // Return 0 if no record is added
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to make a FacturaMetodoPago relation.", ex);
            throw;
        }
    }

    public async Task<int> DeleteFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
    {
        try
        {
            var factura = await dbContext.Facturas.FirstOrDefaultAsync(f => f.FacturaCodigo == facturaCodigo);
            if (factura != null)
            {
                var metodoPago = factura.IdMetodoPagos.FirstOrDefault(mp => mp.IdMetodoPago == idMetodoPago);
                if (metodoPago != null)
                {
                    factura.IdMetodoPagos.Remove(metodoPago);
                    return await dbContext.SaveChangesAsync();
                }
            }
            return 0; // Return 0 if no record is deleted
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to delete a FacturaMetodoPago relation.", ex);
            throw;
        }
    }

    public async Task<IEnumerable<MetodoPago>> GetMetodoPagosAsync(string facturaCodigo)
    {
        try
        {
            var factura = await dbContext.Facturas.FirstOrDefaultAsync(f => f.FacturaCodigo == facturaCodigo);
            return factura?.IdMetodoPagos.ToList() ?? new List<MetodoPago>();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Something went wrong while trying to get FacturaMetodoPagos relations.", ex);
            throw;
        }
    }
}