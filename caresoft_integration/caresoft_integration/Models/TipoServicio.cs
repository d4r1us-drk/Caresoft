using System;
using System.Collections.Generic;

namespace caresoft_integration.Models;

public partial class TipoServicio
{
    public uint IdTipoServicio { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
