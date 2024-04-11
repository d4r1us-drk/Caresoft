namespace caresoft_core.Models;

public partial class Afeccion
{
    public uint IdAfeccion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Consulta> ConsultaCodigos { get; set; } = new List<Consulta>();

    public virtual ICollection<Ingreso> IdIngresos { get; set; } = new List<Ingreso>();
}
