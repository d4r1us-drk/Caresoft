using caresoft_core.Dto;
using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces;

public interface IUsuarioService
{
    public Task<List<UsuarioDto>> GetUsuariosListAsync();
    public Task<int> AddUsuarioAsync(Usuario usuario, PerfilUsuario perfilUsuario);
    public Task<int> UpdateUsuarioAsync(Usuario usuario, PerfilUsuario perfilUsuario);
    public Task<int> DeleteUsuarioAsync(string codigoOdocumento);
}
