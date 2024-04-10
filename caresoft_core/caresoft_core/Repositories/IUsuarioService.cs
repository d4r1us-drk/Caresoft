using caresoft_core.Entities;

namespace caresoft_core.Repositories;

public interface IUsuarioService
{
    public Task<List<PerfilUsuario>> GetUsuariosListAsync(string documento = null, string genero = null, DateTime? fechaNacimiento = null, string rol = null);
    public Task<int> AddUsuarioPacienteAsync(Usuario usuario, PerfilUsuario perfilUsuario);
    public Task<int> AddUsuarioPersonalAsync(Usuario usuario, PerfilUsuario perfilUsuario);
    public Task<int> AddUsuarioMedicoAsync(Usuario usuario, PerfilUsuario perfilUsuario);
    public Task<int> UpdateUsuarioAsync(PerfilUsuario perfilUsuario);
    public Task<int> DeleteUsuarioAsync(string codigoOdocumento);
}
