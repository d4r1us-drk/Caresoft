namespace caresoft_core.Models;

public partial class ProductoDto
{
    public uint? IdProducto { get; set; }

    public string? Nombre { get; set; } = null!;

    public string? Descripcion { get; set; } = null!;

    public decimal? Costo { get; set; } = null!;

    public uint? LoteDisponible { get; set; } = null!;
}
