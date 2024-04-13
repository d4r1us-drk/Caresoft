using caresoft_core.Models;

namespace caresoft_core.Dto;

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
