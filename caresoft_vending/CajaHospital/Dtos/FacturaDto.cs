using System;

namespace CajaHospital
{
    public class FacturaDto
    {
        public string FacturaCodigo { get; set; }
        public uint IdCuenta { get; set; }
        //public string ConsultaCodigo { get; set; }
        //public uint IdIngreso { get; set; }
        public uint IdSucursal { get; set; }
        public string DocumentoCajero { get; set; }
        public decimal MontoSubtotal { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime Fecha { get; set; }
    }
}
