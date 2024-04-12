using caresoft_core.Models;

namespace caresoft_core.Dto;

public class AutorizacionDto
{
    public uint IdAutorizacion { get; set; }
    public uint IdAseguradora { get; set; }
    public DateTime Fecha { get; set; }
    public decimal MontoAsegurado { get; set; }

    public static AutorizacionDto FromAutorizacion(Autorizacion autorizacion)
    {
        return new AutorizacionDto
        {
            IdAutorizacion = autorizacion.IdAutorizacion,
            IdAseguradora = autorizacion.IdAutorizacion,
            Fecha = autorizacion.Fecha,
            MontoAsegurado = autorizacion.MontoAsegurado
        };
    }
}