using caresoft_integration.Models;

namespace caresoft_integration.Dto;

public class ConsultaDto
{
    public string ConsultaCodigo { get; set; }

    public string DocumentoPaciente { get; set; }

    public string DocumentoMedico { get; set; }

    public uint IdConsultorio { get; set; }

    public uint? IdAutorizacion { get; set; }

    public DateTime Fecha { get; set; }

    public string Motivo { get; set; }

    public string? Comentarios { get; set; }

    public string Estado { get; set; }

    public decimal Costo { get; set; }

    static public ConsultaDto FromModel(Consultum consultum)
    {
        return new ConsultaDto
        {
            ConsultaCodigo = consultum.ConsultaCodigo,
            DocumentoPaciente = consultum.DocumentoPaciente,
            DocumentoMedico = consultum.DocumentoMedico,
            IdConsultorio = consultum.IdConsultorio,
            IdAutorizacion = consultum.IdAutorizacion,
            Fecha = consultum.Fecha,
            Motivo = consultum.Motivo,
            Comentarios = consultum.Comentarios,
            Estado = consultum.Estado,
            Costo = consultum.Costo
        };
    }
}
