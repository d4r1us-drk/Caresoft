using caresoft_integration.Models;

namespace caresoft_integration.Dto;

public class FacturaProductoDto
{
    public string FacturaCodigo { get; set; } = null!;
    public uint IdProducto { get; set; }
    public uint? IdAutorizacion { get; set; }
    public string? Resultados { get; set; }
    public decimal Costo { get; set; }

    public static FacturaProductoDto FromModel(FacturaProducto facturaProducto)
    {
        return new FacturaProductoDto
        {
            FacturaCodigo = facturaProducto.FacturaCodigo,
            IdProducto = facturaProducto.IdProducto,
            IdAutorizacion = facturaProducto.IdAutorizacion,
            Resultados = facturaProducto.Resultados,
            Costo = facturaProducto.Costo
        };
    }
}
