using caresoft_core.Dto;

namespace caresoft_core.Models;

public class FacturaServicio
{
    public string FacturaCodigo { get; set; } = null!;

    public string ServicioCodigo { get; set; } = null!;

    public uint? IdAutorizacion { get; set; }

    public string? Resultados { get; set; }

    public decimal Costo { get; set; }

    public virtual Factura FacturaCodigoNavigation { get; set; } = null!;

    public virtual Autorizacion? IdAutorizacionNavigation { get; set; }

    public virtual Servicio ServicioCodigoNavigation { get; set; } = null!;

    public static FacturaServicio FromDto(FacturaServicioDto facturaServicioDto)
    {
        return new FacturaServicio
        {
            FacturaCodigo = facturaServicioDto.FacturaCodigo,
            ServicioCodigo = facturaServicioDto.ServicioCodigo,
            IdAutorizacion = facturaServicioDto.IdAutorizacion,
            Resultados = facturaServicioDto.Resultados,
            Costo = facturaServicioDto.Costo
        };
    }
}
