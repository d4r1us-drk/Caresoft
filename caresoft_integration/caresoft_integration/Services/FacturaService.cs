using caresoft_integration.Client;
using caresoft_integration.Dto;
using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_integration.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly FallbackHttpClient _fallbackHttpClient;

        public FacturaService(FallbackHttpClient fallbackHttpClient)
        {
            _fallbackHttpClient = fallbackHttpClient;
        }

        public async Task<int> AddFacturaAsync(FacturaDto facturaDto)
        {
            return await _fallbackHttpClient.AddFacturaAsync(facturaDto);
        }

        public async Task<int> UpdateFacturaAsync(FacturaDto facturaDto)
        {
            return await _fallbackHttpClient.UpdateFacturaAsync(facturaDto);
        }

        public async Task<int> DeleteFacturaAsync(string facturaCodigo)
        {
            return await _fallbackHttpClient.DeleteFacturaAsync(facturaCodigo);
        }

        public async Task<IEnumerable<FacturaDto>> GetFacturasAsync()
        {
            return await _fallbackHttpClient.GetFacturasAsync();
        }

        public async Task<int> AddFacturaServicioAsync(FacturaServicioDto facturaServicioDto)
        {
            return await _fallbackHttpClient.AddFacturaServicioAsync(facturaServicioDto);
        }

        public async Task<int> DeleteFacturaServicioAsync(string facturaCodigo, string servicioCodigo)
        {
            return await _fallbackHttpClient.DeleteFacturaServicioAsync(facturaCodigo, servicioCodigo);
        }

        public async Task<IEnumerable<FacturaServicioDto>> GetFacturaServiciosAsync(string facturaCodigo)
        {
            return (IEnumerable<FacturaServicioDto>)await _fallbackHttpClient.GetFacturaServiciosAsync(facturaCodigo);
        }

        public async Task<int> AddFacturaProductoAsync(FacturaProductoDto facturaProductoDto)
        {
            return await _fallbackHttpClient.AddFacturaProductoAsync(facturaProductoDto);
        }

        public async Task<int> DeleteFacturaProductoAsync(string facturaCodigo, uint idProducto)
        {
            return await _fallbackHttpClient.DeleteFacturaProductoAsync(facturaCodigo, idProducto);
        }

        public async Task<IEnumerable<FacturaProductoDto>> GetFacturaProductosAsync(string facturaCodigo)
        {
            return await _fallbackHttpClient.GetFacturaProductosAsync(facturaCodigo);
        }

        public async Task<int> AddFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
        {
            return await _fallbackHttpClient.AddFacturaMetodoPagoAsync(facturaCodigo, idMetodoPago);
        }

        public async Task<int> DeleteFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
        {
            return await _fallbackHttpClient.DeleteFacturaMetodoPagoAsync(facturaCodigo, idMetodoPago);
        }

        public async Task<IEnumerable<MetodoPago>> GetMetodoPagosAsync(string facturaCodigo)
        {
            return (IEnumerable<MetodoPago>)await _fallbackHttpClient.GetMetodoPagosAsync(facturaCodigo);
        }
    }
}
