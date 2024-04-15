namespace caresoft_core_client.Models
{
    internal class Proveedor
    {
        public uint RncProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
    }
}
