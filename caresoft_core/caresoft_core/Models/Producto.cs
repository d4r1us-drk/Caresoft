using System;
using System.Collections.Generic;

namespace caresoft_core.Models;

public partial class Producto
{
    public uint IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Costo { get; set; }

    public uint LoteDisponible { get; set; }

    public virtual ICollection<FacturaProducto> FacturaProductos { get; set; } = new List<FacturaProducto>();

    public virtual ICollection<PrescripcionProducto> PrescripcionProductos { get; set; } = new List<PrescripcionProducto>();

    public virtual ICollection<Proveedor> RncProveedors { get; set; } = new List<Proveedor>();
}
