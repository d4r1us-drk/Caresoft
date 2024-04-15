using caresoft_core.Models;

namespace caresoft_core.Dto;

public class ProveedorDto
{
    public uint RncProveedor { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string Correo { get; set; } = null!;

    public static ProveedorDto FromModel(Proveedor proveedor)
    {
        return new ProveedorDto
        {
            RncProveedor = proveedor.RncProveedor,
            Nombre = proveedor.Nombre,
            Direccion = proveedor.Direccion,
            Telefono = proveedor.Telefono,
            Correo = proveedor.Correo
        };
    }
}