using System;
using System.Collections.Generic;

namespace caresoft_core.Models;

public partial class Sucursal
{
    public uint IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
