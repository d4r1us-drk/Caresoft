using System;
using System.Collections.Generic;

namespace caresoft_core.Entities;

public partial class Sala
{
    public uint NumSala { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
}
