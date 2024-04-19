using System;

namespace CajaHospital
{
    public class CuadreDto
    {
        public uint IdCuadre { get; set; }
        public string DocumentoCajero { get; set; }
        public uint IdSucursal { get; set; }
        public decimal MontoDescargado { get; set; }
        public DateTime Fecha { get; set; }
    }

}
