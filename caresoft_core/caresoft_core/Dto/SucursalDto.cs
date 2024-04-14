using caresoft_core.Models;

namespace caresoft_core.Dto;

public class SucursalDto
{
    public uint IdSucursal { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }

    public static SucursalDto FromModel(Sucursal sucursal)
    {
        return new SucursalDto
        {
            IdSucursal = sucursal.IdSucursal,
            Nombre = sucursal.Nombre,
            Direccion = sucursal.Direccion,
            Telefono = sucursal.Telefono
        };
    }
}