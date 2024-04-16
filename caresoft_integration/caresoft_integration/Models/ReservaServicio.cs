using caresoft_integration.Dto;

namespace caresoft_integration.Models;

public class ReservaServicio
{
    public uint IdReserva { get; set; }

    public string DocumentoPaciente { get; set; } = null!;

    public string DocumentoMedico { get; set; } = null!;

    public string ServicioCodigo { get; set; } = null!;

    public DateTime FechaReservada { get; set; }

    public string Estado { get; set; } = null!;

    public virtual PerfilUsuario DocumentoMedicoNavigation { get; set; } = null!;

    public virtual PerfilUsuario DocumentoPacienteNavigation { get; set; } = null!;

    public virtual Servicio ServicioCodigoNavigation { get; set; } = null!;

    public static ReservaServicio FromDto(ReservaServicioDto dto)
    {
        return new ReservaServicio
        {
            IdReserva = dto.IdReserva,
            DocumentoPaciente = dto.DocumentoPaciente,
            DocumentoMedico = dto.DocumentoMedico,
            ServicioCodigo = dto.ServicioCodigo,
            FechaReservada = dto.FechaReservada,
            Estado = dto.Estado
        };
    }
}
