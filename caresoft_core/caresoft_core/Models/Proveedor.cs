using caresoft_core.Dto;

namespace caresoft_core.Models;

public class Proveedor
{
    public uint RncProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Producto> IdProductos { get; set; } = new List<Producto>();

    public static Proveedor FromDto(ProveedorDto dto)
    {
        return new Proveedor
        {
            RncProveedor = dto.RncProveedor,
            Nombre = dto.Nombre,
            Direccion = dto.Direccion,
            Telefono = dto.Telefono,
            Correo = dto.Correo
        };
    }
}
