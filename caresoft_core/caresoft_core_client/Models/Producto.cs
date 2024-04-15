namespace caresoft_core_client.Models
{
    internal class Producto
    {
        public uint IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Costo { get; set; }
        public uint LoteDisponible { get; set; }
        public virtual ICollection<Proveedor> RncProveedors { get; set; } = new List<Proveedor>();
    }
}
