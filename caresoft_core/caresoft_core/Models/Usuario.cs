using caresoft_core.Dto;

namespace caresoft_core.Models;

public partial class Usuario
{
    public string UsuarioCodigo { get; set; } = null!;

    public string DocumentoUsuario { get; set; } = null!;

    public string UsuarioContra { get; set; } = null!;

    public virtual PerfilUsuario DocumentoUsuarioNavigation { get; set; } = null!;

    public static Usuario FromDto(UsuarioDto usuarioDto)
    {
        return new Usuario
        {
            UsuarioCodigo = usuarioDto.UsuarioCodigo,
            DocumentoUsuario = usuarioDto.Documento,
            UsuarioContra = usuarioDto.UsuarioContra
        };
    }
}
