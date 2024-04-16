using caresoft_integration.Dto;

namespace caresoft_integration.Models;

public partial class Autorizacion
{
    public uint IdAutorizacion { get; set; }

    public uint IdAseguradora { get; set; }

    public DateTime Fecha { get; set; }

    public decimal MontoAsegurado { get; set; }

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual FacturaProducto? FacturaProducto { get; set; }

    public virtual FacturaServicio? FacturaServicio { get; set; }

    public virtual Aseguradora IdAseguradoraNavigation { get; set; } = null!;

    public virtual ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();

    public static Autorizacion FromDto(AutorizacionDto autorizacionDto)
    {
        return new Autorizacion
        {
            IdAutorizacion = autorizacionDto.IdAutorizacion,
            IdAseguradora = autorizacionDto.IdAseguradora,
            Fecha = autorizacionDto.Fecha,
            MontoAsegurado = autorizacionDto.MontoAsegurado
        };
    }
}
