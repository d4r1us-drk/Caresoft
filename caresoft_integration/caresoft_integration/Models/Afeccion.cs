namespace caresoft_integration.Models;

public class Afeccion
{
    public uint IdAfeccion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Consultum> ConsultaCodigos { get; set; } = new List<Consultum>();

    public virtual ICollection<Ingreso> IdIngresos { get; set; } = new List<Ingreso>();
}
