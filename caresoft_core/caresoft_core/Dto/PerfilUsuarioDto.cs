namespace caresoft_core.Dto;

public class PerfilUsuarioDto
{
    public string Documento { get; set; }
    public string TipoDocumento { get; set; }
    public uint NumLicenciaMedica { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public string Direccion { get; set; }
    public string Rol { get; set; }
}
