using caresoft_core.Models;

namespace caresoft_core.Dto;

public class ReservaServicioDto
{
    public uint IdReserva { get; set; }

    public string DocumentoPaciente { get; set; }

    public string DocumentoMedico { get; set; }

    public string ServicioCodigo { get; set; }

    public DateTime FechaReservada { get; set; }

    public string Estado { get; set; }

    public static ReservaServicioDto FromModel(ReservaServicio model)
    {
        return new ReservaServicioDto
        {
            IdReserva = model.IdReserva,
            DocumentoPaciente = model.DocumentoPaciente,
            DocumentoMedico = model.DocumentoMedico,
            ServicioCodigo = model.ServicioCodigo,
            FechaReservada = model.FechaReservada,
            Estado = model.Estado
        };
    }
}
