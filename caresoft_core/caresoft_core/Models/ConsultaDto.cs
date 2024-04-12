namespace caresoft_core.Models
{
    public class ConsultaDto
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
    }
}
