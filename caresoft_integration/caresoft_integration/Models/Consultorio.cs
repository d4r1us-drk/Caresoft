namespace caresoft_integration.Models;

public class Consultorio
{
    public uint IdConsultorio { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();
}
