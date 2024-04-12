namespace caresoft_core.Dto;

public class UsuarioDto
{
    public string? UsuarioCodigo { get; set; } = null!;
    public string? Documento { get; set; } = null!;
    public string? UsuarioContra { get; set; } = null!;
    public string? TipoDocumento { get; set; } = null!;
    public uint? NumLicenciaMedica { get; set; }
    public string? Nombre { get; set; } = null!;
    public string? Apellido { get; set; } = null!;
    public string? Genero { get; set; } = null!;
    public DateTime? FechaNacimiento { get; set; }
    public string? Telefono { get; set; } = null!;
    public string? Correo { get; set; } = null!;
    public string? Direccion { get; set; } = null!;
    public string? Rol { get; set; } = null!;
}
