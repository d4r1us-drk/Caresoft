using caresoft_core.Dto;

namespace caresoft_core.Models;

public class Ingreso
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

    public static Ingreso FromDto(IngresoDto dto)
    {
        return new Ingreso
        {
            IdIngreso = dto.IdIngreso,
            DocumentoPaciente = dto.DocumentoPaciente,
            DocumentoEnfermero = dto.DocumentoEnfermero,
            DocumentoMedico = dto.DocumentoMedico,
            ConsultaCodigo = dto.ConsultaCodigo,
            IdAutorizacion = dto.IdAutorizacion,
            NumSala = dto.NumSala,
            CostoEstancia = dto.CostoEstancia,
            FechaIngreso = dto.FechaIngreso,
            FechaAlta = dto.FechaAlta
        };
    }
}
