namespace caresoft_integration.Dto;

public class AseguradoraDto
{
    public uint? IdAseguradora { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;
}