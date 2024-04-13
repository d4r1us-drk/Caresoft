using caresoft_core.Dto;

namespace caresoft_core.Models;

public class FacturaProducto
{
    public string FacturaCodigo { get; set; } = null!;

    public uint IdProducto { get; set; }

    public uint? IdAutorizacion { get; set; }

    public string? Resultados { get; set; }

    public decimal Costo { get; set; }

    public Factura FacturaCodigoNavigation { get; set; } = null!;

    public Autorizacion? IdAutorizacionNavigation { get; set; }

    public Producto IdProductoNavigation { get; set; } = null!;

    public static FacturaProducto FromDto(FacturaProductoDto facturaProductoDto)
    {
        return new FacturaProducto
        {
            FacturaCodigo = facturaProductoDto.FacturaCodigo,
            IdProducto = facturaProductoDto.IdProducto,
            IdAutorizacion = facturaProductoDto.IdAutorizacion,
            Resultados = facturaProductoDto.Resultados,
            Costo = facturaProductoDto.Costo
        };
    }
}
