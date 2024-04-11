namespace caresoft_core.Models;

public partial class Servicio
{
    public string ServicioCodigo { get; set; } = null!;

    public uint IdTipoServicio { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Costo { get; set; }

    public virtual ICollection<FacturaServicio> FacturaServicios { get; set; } = new List<FacturaServicio>();

    public virtual TipoServicio IdTipoServicioNavigation { get; set; } = null!;

    public virtual ICollection<ReservaServicio> ReservaServicios { get; set; } = new List<ReservaServicio>();

    public virtual ICollection<Consulta> ConsultaCodigos { get; set; } = new List<Consulta>();
}
