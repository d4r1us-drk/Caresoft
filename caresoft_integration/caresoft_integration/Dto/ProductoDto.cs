using caresoft_integration.Models;

namespace caresoft_integration.Dto;

public class ProductoDto
{
    public uint IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Costo { get; set; }

    public uint LoteDisponible { get; set; }

    public static ProductoDto FromModel(Producto model)
    {
        return new ProductoDto
        {
            IdProducto = model.IdProducto,
            Nombre = model.Nombre,
            Descripcion = model.Descripcion,
            Costo = model.Costo,
            LoteDisponible = model.LoteDisponible
        };
    }
}
