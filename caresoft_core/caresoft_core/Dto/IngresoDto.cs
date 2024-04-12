namespace caresoft_core.Dto
{
    public class IngresoDto
    {
        public uint? IdIngreso { get; set; }
        public string DocumentoPaciente { get; set; }
        public string DocumentoEnfermero { get; set; }
        public string DocumentoMedico { get; set; }
        public string? ConsultaCodigo { get; set; }
        public uint? IdAutorizacion { get; set; }
        public uint NumSala { get; set; }
        public decimal CostoEstancia { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaAlta { get; set; }
    }
}
