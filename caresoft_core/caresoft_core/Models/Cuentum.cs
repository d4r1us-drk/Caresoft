using System;
using System.Collections.Generic;

namespace caresoft_core.Models;

public partial class Cuentum
{
    public uint IdCuenta { get; set; }

    public string DocumentoUsuario { get; set; } = null!;

    public decimal Balance { get; set; }

    public string Estado { get; set; } = null!;

    public virtual PerfilUsuario DocumentoUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
