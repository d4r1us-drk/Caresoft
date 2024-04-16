using caresoft_integration.Dto;

namespace caresoft_integration.Models;

public class Factura
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

    public virtual Consultum? ConsultaCodigoNavigation { get; set; }

    public virtual PerfilUsuario DocumentoCajeroNavigation { get; set; } = null!;

    public virtual ICollection<FacturaProducto> FacturaProductos { get; set; } = new List<FacturaProducto>();

    public virtual ICollection<FacturaServicio> FacturaServicios { get; set; } = new List<FacturaServicio>();

    public virtual Cuentum IdCuentaNavigation { get; set; } = null!;

    public virtual Ingreso? IdIngresoNavigation { get; set; }

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<MetodoPago> IdMetodoPagos { get; set; } = new List<MetodoPago>();

    public static Factura FromDto(FacturaDto facturaDto)
    {
        return new Factura
        {
            FacturaCodigo = facturaDto.FacturaCodigo,
            IdCuenta = facturaDto.IdCuenta,
            ConsultaCodigo = facturaDto.ConsultaCodigo,
            IdIngreso = facturaDto.IdIngreso,
            IdSucursal = facturaDto.IdSucursal,
            DocumentoCajero = facturaDto.DocumentoCajero,
            MontoSubtotal = facturaDto.MontoSubtotal,
            MontoTotal = facturaDto.MontoTotal,
            Fecha = facturaDto.Fecha
        };
    }
}
