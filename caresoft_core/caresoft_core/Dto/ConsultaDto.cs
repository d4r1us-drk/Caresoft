using caresoft_core.Models;

namespace caresoft_core.Dto;

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

    static public ConsultaDto FromModel(Consulta consulta)
    {
        return new ConsultaDto
        {
            ConsultaCodigo = consulta.ConsultaCodigo,
            DocumentoPaciente = consulta.DocumentoPaciente,
            DocumentoMedico = consulta.DocumentoMedico,
            IdConsultorio = consulta.IdConsultorio,
            IdAutorizacion = consulta.IdAutorizacion,
            Fecha = consulta.Fecha,
            Motivo = consulta.Motivo,
            Comentarios = consulta.Comentarios,
            Estado = consulta.Estado,
            Costo = consulta.Costo
        };
    }

}
