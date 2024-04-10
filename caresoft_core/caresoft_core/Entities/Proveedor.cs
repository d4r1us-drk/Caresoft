using System;
using System.Collections.Generic;

namespace caresoft_core.Entities;

public partial class Proveedor
{
    public uint RncProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Producto> IdProductos { get; set; } = new List<Producto>();
}
