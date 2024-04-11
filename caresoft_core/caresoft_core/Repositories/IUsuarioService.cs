using caresoft_core.Entities;
using caresoft_core.Dto;

namespace caresoft_core.Repositories;

public interface IUsuarioService
{
    public Task<List<UsuarioDto>> GetUsuariosListAsync(string? documento, string? genero, DateTime? fechaNacimiento, string? rol);
    public Task<int> AddUsuarioPacienteAsync(Usuario usuario, PerfilUsuario perfilUsuario);
    public Task<int> AddUsuarioPersonalAsync(Usuario usuario, PerfilUsuario perfilUsuario);
    public Task<int> AddUsuarioMedicoAsync(Usuario usuario, PerfilUsuario perfilUsuario);
    public Task<int> UpdateUsuarioAsync(Usuario usuario, PerfilUsuario perfilUsuario);
    public Task<int> DeleteUsuarioAsync(string codigoOdocumento);
}
