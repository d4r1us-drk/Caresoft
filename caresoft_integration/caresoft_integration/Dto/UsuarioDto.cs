using caresoft_core.Models;

namespace caresoft_core.Dto;

public class UsuarioDto
{
    public string UsuarioCodigo { get; set; } = null!;
    public string Documento { get; set; } = null!;
    public string UsuarioContra { get; set; } = null!;
    public string TipoDocumento { get; set; } = null!;
    public uint? NumLicenciaMedica { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Genero { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public string Telefono { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string? Direccion { get; set; } = null!;
    public string Rol { get; set; } = null!;

    static public UsuarioDto FromModel(Usuario usuario)
    {
        return new UsuarioDto
        {
            UsuarioCodigo = usuario.UsuarioCodigo,
            Documento = usuario.DocumentoUsuario,
            UsuarioContra = usuario.UsuarioContra,
            TipoDocumento = usuario.DocumentoUsuarioNavigation.TipoDocumento,
            NumLicenciaMedica = usuario.DocumentoUsuarioNavigation.NumLicenciaMedica,
            Nombre = usuario.DocumentoUsuarioNavigation.Nombre,
            Apellido = usuario.DocumentoUsuarioNavigation.Apellido,
            Genero = usuario.DocumentoUsuarioNavigation.Genero,
            FechaNacimiento = usuario.DocumentoUsuarioNavigation.FechaNacimiento,
            Telefono = usuario.DocumentoUsuarioNavigation.Telefono,
            Correo = usuario.DocumentoUsuarioNavigation.Correo,
            Direccion = usuario.DocumentoUsuarioNavigation.Direccion,
            Rol = usuario.DocumentoUsuarioNavigation.Rol
        };
    }
}
