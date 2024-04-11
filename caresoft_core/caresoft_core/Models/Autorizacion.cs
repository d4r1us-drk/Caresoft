﻿namespace caresoft_core.Models;

public partial class Autorizacion
{
    public uint IdAutorizacion { get; set; }

    public uint IdAseguradora { get; set; }

    public DateTime Fecha { get; set; }

    public decimal MontoAsegurado { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual FacturaProducto? FacturaProducto { get; set; }

    public virtual FacturaServicio? FacturaServicio { get; set; }

    public virtual Aseguradora IdAseguradoraNavigation { get; set; } = null!;

    public virtual ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
}