using caresoft_core.Dto;

namespace caresoft_core.Models;

public class Sucursal
{
    public uint IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public static Sucursal FromDto(SucursalDto sucursalDto)
    {
        return new Sucursal
        {
            IdSucursal = sucursalDto.IdSucursal,
            Nombre = sucursalDto.Nombre,
            Direccion = sucursalDto.Direccion,
            Telefono = sucursalDto.Telefono
        };
    }
}
