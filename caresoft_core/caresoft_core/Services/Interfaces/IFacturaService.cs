using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces;
public interface IFacturaService
{
    Task<int> AddFacturaAsync(Factura factura);
    Task<int> UpdateFacturaAsync(Factura factura);
    Task<int> DeleteFacturaAsync(string facturaCodigo);
    Task<IEnumerable<Factura>> GetFacturasAsync();
    Task<int> AddFacturaServicioAsync(FacturaServicio facturaServicio);
    Task<int> DeleteFacturaServicioAsync(string facturaCodigo, string servicioCodigo);
    Task<IEnumerable<FacturaServicio>> GetFacturaServiciosAsync(string facturaCodigo);
    Task<int> AddFacturaProductoAsync(FacturaProducto facturaProducto);
    Task<int> DeleteFacturaProductoAsync(string facturaCodigo, uint idProducto);
    Task<IEnumerable<FacturaProducto>> GetFacturaProductosAsync(string facturaCodigo);
    Task<int> AddFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago);
    Task<int> DeleteFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago);
    Task<IEnumerable<MetodoPago>> GetMetodoPagosAsync(string facturaCodigo);
}
