using caresoft_integration.Models;

namespace caresoft_integration.Dto;

public class FacturaDto
{
    public string FacturaCodigo { get; set; } = null!;
    public uint IdCuenta { get; set; }
    public string? ConsultaCodigo { get; set; }
    public uint? IdIngreso { get; set; }
    public uint IdSucursal { get; set; }
    public string DocumentoCajero { get; set; } = null!;
    public decimal MontoSubtotal { get; set; }
    public decimal MontoTotal { get; set; }
    public DateTime Fecha { get; set; }

    public static FacturaDto FromModel(Factura factura)
    {
        return new FacturaDto
        {
            FacturaCodigo = factura.FacturaCodigo,
            IdCuenta = factura.IdCuenta,
            ConsultaCodigo = factura.ConsultaCodigo,
            IdIngreso = factura.IdIngreso,
            IdSucursal = factura.IdSucursal,
            DocumentoCajero = factura.DocumentoCajero,
            MontoSubtotal = factura.MontoSubtotal,
            MontoTotal = factura.MontoTotal,
            Fecha = factura.Fecha
        };
    }
}