namespace caresoft_core.Dto;

public partial class ReservaServicioDto
{
    public uint? IdReserva { get; set; } = null!;

    public string? DocumentoPaciente { get; set; } = null!;

    public string? DocumentoMedico { get; set; } = null!;

    public string? ServicioCodigo { get; set; } = null!;

    public DateTime? FechaReservada { get; set; }

    public string? Estado { get; set; } = null!;
}
