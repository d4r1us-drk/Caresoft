namespace caresoft_core.Models;

public partial class PrescripcionProducto
{
    public string ConsultaCodigo { get; set; } = null!;

    public uint IdProducto { get; set; }

    public int Cantidad { get; set; }

    public virtual Consulta ConsultaCodigoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
