namespace caresoft_core.Models;

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

    public virtual ICollection<Consulta> ConsultaDocumentoMedicoNavigations { get; set; } = new List<Consulta>();

    public virtual ICollection<Consulta> ConsultaDocumentoPacienteNavigations { get; set; } = new List<Consulta>();

    public virtual Cuenta? Cuenta { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Ingreso> IngresoDocumentoEnfermeroNavigations { get; set; } = new List<Ingreso>();

    public virtual ICollection<Ingreso> IngresoDocumentoMedicoNavigations { get; set; } = new List<Ingreso>();

    public virtual ICollection<Ingreso> IngresoDocumentoPacienteNavigations { get; set; } = new List<Ingreso>();

    public virtual ICollection<ReservaServicio> ReservaServicioDocumentoMedicoNavigations { get; set; } = new List<ReservaServicio>();

    public virtual ICollection<ReservaServicio> ReservaServicioDocumentoPacienteNavigations { get; set; } = new List<ReservaServicio>();

    public virtual Usuario? Usuario { get; set; }
}
