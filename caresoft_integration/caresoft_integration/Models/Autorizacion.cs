using caresoft_integration.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace caresoft_integration.Models;

public partial class Autorizacion
{
    [NotMapped]
    public object CodigoAutorizacion { get; set; }
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
    public static Autorizacion FromCoreApi(caresoft_integration.CoreAPI.Autorizacion autorizacion)
    {
        return new Autorizacion
        {
            IdAutorizacion = (uint)autorizacion.IdAutorizacion,
            IdAseguradora = (uint)autorizacion.IdAseguradora,
            Fecha = autorizacion.Fecha.Date,
            MontoAsegurado = (decimal)autorizacion.MontoAsegurado
        };
    }
    public static caresoft_integration.CoreAPI.Autorizacion ToCoreApi(Autorizacion autorizacion)
    {
        return new()
        {
            IdAutorizacion = (int)autorizacion.IdAutorizacion,
            IdAseguradora = (int)autorizacion.IdAseguradora,
            Fecha = autorizacion.Fecha,
            MontoAsegurado = (double)autorizacion.MontoAsegurado
        };
    }
}
