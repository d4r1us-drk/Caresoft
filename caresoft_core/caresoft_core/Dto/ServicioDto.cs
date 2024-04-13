namespace caresoft_core.Dto;

public class ServicioDto
{
    public string ServicioCodigo { get; set; }
    public uint IdTipoServicio { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Costo { get; set; }
}