using System;
using System.Collections.Generic;

namespace caresoft_core.Models;

public partial class FacturaProducto
{
    public string FacturaCodigo { get; set; } = null!;

    public uint IdProducto { get; set; }

    public uint? IdAutorizacion { get; set; }

    public string? Resultados { get; set; }

    public decimal Costo { get; set; }

    public virtual Factura FacturaCodigoNavigation { get; set; } = null!;

    public virtual Autorizacion? IdAutorizacionNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
