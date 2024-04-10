using System;
using System.Collections.Generic;

namespace caresoft_core.Entities;

public partial class PrescripcionProducto
{
    public string ConsultaCodigo { get; set; } = null!;

    public uint IdProducto { get; set; }

    public int Cantidad { get; set; }

    public virtual Consultum ConsultaCodigoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
