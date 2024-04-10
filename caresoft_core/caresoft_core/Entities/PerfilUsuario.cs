using System;
using System.Collections.Generic;

namespace caresoft_core.Entities;

public partial class PerfilUsuario
{
    public string Documento { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public uint? NumLicenciaMedica { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Direccion { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<Consultum> ConsultumDocumentoMedicoNavigations { get; set; } = new List<Consultum>();

    public virtual ICollection<Consultum> ConsultumDocumentoPacienteNavigations { get; set; } = new List<Consultum>();

    public virtual Cuentum? Cuentum { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Ingreso> IngresoDocumentoEnfermeroNavigations { get; set; } = new List<Ingreso>();

    public virtual ICollection<Ingreso> IngresoDocumentoMedicoNavigations { get; set; } = new List<Ingreso>();

    public virtual ICollection<Ingreso> IngresoDocumentoPacienteNavigations { get; set; } = new List<Ingreso>();

    public virtual ICollection<ReservaServicio> ReservaServicioDocumentoMedicoNavigations { get; set; } = new List<ReservaServicio>();

    public virtual ICollection<ReservaServicio> ReservaServicioDocumentoPacienteNavigations { get; set; } = new List<ReservaServicio>();

    public virtual Usuario? Usuario { get; set; }
}
