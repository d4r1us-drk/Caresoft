namespace caresoft_core.Models;

public partial class Pago
{
    public uint IdPago { get; set; }

    public uint IdCuenta { get; set; }

    public decimal MontoPagado { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Cuenta IdCuentaNavigation { get; set; } = null!;
}
