using caresoft_core.Models;

namespace caresoft_core.Dto;

public class FacturaServicioDto
{
    public string FacturaCodigo { get; set; } = null!;

    public string ServicioCodigo { get; set; } = null!;

    public uint? IdAutorizacion { get; set; }

    public string? Resultados { get; set; }

    public decimal Costo { get; set; }

    public static FacturaServicioDto FromModel(FacturaServicio facturaServicio)
    {
        return new FacturaServicioDto
        {
            FacturaCodigo = facturaServicio.FacturaCodigo,
            ServicioCodigo = facturaServicio.ServicioCodigo,
            IdAutorizacion = facturaServicio.IdAutorizacion,
            Resultados = facturaServicio.Resultados,
            Costo = facturaServicio.Costo
        };
    }
}