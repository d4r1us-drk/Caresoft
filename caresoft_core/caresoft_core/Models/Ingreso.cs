using System;
using System.Collections.Generic;

namespace caresoft_core.Models;

public partial class Ingreso
{
    public uint IdIngreso { get; set; }

    public string DocumentoPaciente { get; set; } = null!;

    public string DocumentoEnfermero { get; set; } = null!;

    public string DocumentoMedico { get; set; } = null!;

    public string? ConsultaCodigo { get; set; }

    public uint? IdAutorizacion { get; set; }

    public uint NumSala { get; set; }

    public decimal CostoEstancia { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime? FechaAlta { get; set; }

    public virtual PerfilUsuario DocumentoEnfermeroNavigation { get; set; } = null!;

    public virtual PerfilUsuario DocumentoMedicoNavigation { get; set; } = null!;

    public virtual PerfilUsuario DocumentoPacienteNavigation { get; set; } = null!;

    public virtual Factura? Factura { get; set; }

    public virtual Autorizacion? IdAutorizacionNavigation { get; set; }

    public virtual Sala NumSalaNavigation { get; set; } = null!;

    public virtual ICollection<Afeccion> IdAfeccions { get; set; } = new List<Afeccion>();
}
