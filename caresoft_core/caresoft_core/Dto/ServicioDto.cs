using caresoft_core.Models;

namespace caresoft_core.Dto;

public class ServicioDto
{
    public string ServicioCodigo { get; set; }
    public uint IdTipoServicio { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Costo { get; set; }

    public static ServicioDto FromModel(Servicio servicio)
    {
        return new ServicioDto
        {
            ServicioCodigo = servicio.ServicioCodigo,
            IdTipoServicio = servicio.IdTipoServicio,
            Nombre = servicio.Nombre,
            Descripcion = servicio.Descripcion,
            Costo = servicio.Costo
        };
    }
}