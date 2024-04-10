namespace caresoft_core.Entities;

public partial class Usuario
{
    public string UsuarioCodigo { get; set; } = null!;

    public string DocumentoUsuario { get; set; } = null!;

    public string UsuarioContra { get; set; } = null!;

    public virtual PerfilUsuario DocumentoUsuarioNavigation { get; set; } = null!;
}
