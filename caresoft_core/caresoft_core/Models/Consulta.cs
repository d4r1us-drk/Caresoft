using caresoft_core.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace caresoft_core.Models;

[Table("Consulta")]
public partial class Consulta
{
    public string ConsultaCodigo { get; set; } = null!;

    public string DocumentoPaciente { get; set; } = null!;

    public string DocumentoMedico { get; set; } = null!;

    public uint IdConsultorio { get; set; }

    public uint? IdAutorizacion { get; set; }

    public DateTime Fecha { get; set; }

    public string Motivo { get; set; } = null!;

    public string? Comentarios { get; set; }

    public string Estado { get; set; } = null!;

    public decimal Costo { get; set; }

    public virtual PerfilUsuario DocumentoMedicoNavigation { get; set; } = null!;

    public virtual PerfilUsuario DocumentoPacienteNavigation { get; set; } = null!;

    public virtual Factura? Factura { get; set; }

    public virtual Autorizacion? IdAutorizacionNavigation { get; set; }

    public virtual Consultorio IdConsultorioNavigation { get; set; } = null!;

    public virtual ICollection<PrescripcionProducto> PrescripcionProductos { get; set; } = new List<PrescripcionProducto>();

    public virtual ICollection<Afeccion> IdAfeccions { get; set; } = new List<Afeccion>();

    public virtual ICollection<Servicio> ServicioCodigos { get; set; } = new List<Servicio>();

    // Map to Dto
    public static Consulta FromDto(ConsultaDto consultaDto)
    {
        return new Consulta
        {
            ConsultaCodigo = consultaDto.ConsultaCodigo,
            DocumentoPaciente = consultaDto.DocumentoPaciente,
            DocumentoMedico = consultaDto.DocumentoMedico,
            IdConsultorio = consultaDto.IdConsultorio,
            IdAutorizacion = consultaDto.IdAutorizacion,
            Fecha = consultaDto.Fecha,
            Motivo = consultaDto.Motivo,
            Comentarios = consultaDto.Comentarios,
            Estado = consultaDto.Estado,
            Costo = consultaDto.Costo
        };
    }
}
