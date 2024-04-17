using caresoft_core.Dto;

namespace caresoft_core.Models;

public class Pago
{
    public uint IdPago { get; set; }

    public uint IdCuenta { get; set; }

    public decimal MontoPagado { get; set; }

    public DateTime Fecha { get; set; }

    public static Pago FromDto(PagoDto dto)
    {
        return new Pago
        {
            IdPago = dto.IdPago,
            IdCuenta = dto.IdCuenta,
            MontoPagado = dto.MontoPagado,
            Fecha = dto.Fecha
        };
    }

    public virtual Cuentum IdCuentaNavigation { get; set; } = null!;
}
