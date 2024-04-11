namespace caresoft_core.Models;

public partial class Aseguradora
{
    public uint IdAseguradora { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Autorizacion> Autorizacions { get; set; } = new List<Autorizacion>();
}
