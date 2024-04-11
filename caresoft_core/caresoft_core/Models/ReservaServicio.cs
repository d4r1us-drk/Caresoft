namespace caresoft_core.Models;

public partial class ReservaServicio
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
}
