using caresoft_core.Models;

namespace caresoft_core.Dto
{
    public class PagoDto
    {
        public uint IdPago { get; set; }

        public uint IdCuenta { get; set; }

        public decimal MontoPagado { get; set; }

        public DateTime Fecha { get; set; }

        public static PagoDto FromModel(Pago model)
        {
            return new PagoDto
            {
                IdPago = model.IdPago,
                IdCuenta = model.IdCuenta,
                MontoPagado = model.MontoPagado,
                Fecha = model.Fecha
            };
        }
    }
}
